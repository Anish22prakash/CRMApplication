using AutoMapper;
using CustomerRelationshipManagementBackend.Data;
using CustomerRelationshipManagementBackend.Helper;
using CustomerRelationshipManagementBackend.Model;
using CustomerRelationshipManagementBackend.ModelDto;
using Microsoft.EntityFrameworkCore;
using CustomerRelationshipManagementBackend.Common;

namespace CustomerRelationshipManagementBackend.Service.UserServices
{
    public class Userservice : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _pepper;
        private readonly int _iteration = 3;
        private readonly IMapper _mapper;
        private readonly ILogger<Userservice> _logger;
        private readonly IWebHostEnvironment _environment;

        public Userservice(ApplicationDbContext context , IMapper mapper, ILogger<Userservice> logger, IWebHostEnvironment environment)
        {
            _context = context;
            _pepper = Environment.GetEnvironmentVariable("PasswordHashPepper");
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
        }

        public async Task<IList<Users>> GetAllUserByFilter(int page, int pageSize, string? search)
        {
            try
            {
                if (page < 1)
                {
                    throw new ArgumentException("Page number must be greater than or equal to 1.");
                }

                if (pageSize < 1)
                {
                    throw new ArgumentException("Page size must be greater than or equal to 1.");
                }

                var query = _context.Users.AsQueryable();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(u => u.FirstName.Contains(search) || u.LastName.Contains(search)
                                        || u.UserMobile.Contains(search));
                }

                var users = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                this._logger.LogInformation($"Users data retrieved for page {page} with page size  and search criteria", page, pageSize, search);

                return users;
            }
            catch (Exception ex)
            {
                this._logger.LogError(default(EventId), ex, "GetAllUserByFilter", page, pageSize, search);
                throw;
            }
        }

        public async Task<Users> GetUserAsync(int userId)
        {
            try
            {
               var user = await _context.Users.FirstOrDefaultAsync(u => u.UserID == userId);
                if(user == null)
                {
                    _logger.LogInformation("user is not found");
                    return null;
                }
                return user;

            }catch (Exception ex)
            {
                _logger.LogError(default(EventId), ex, "GetUserAsync");
                throw;
            }
        }

        public async Task<Users> loginUserAsync(UserLoginDto userDto)
        {
            try
            {
              var exisitingUser= await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == userDto.UserEmail);
                if (exisitingUser == null)
                {
                    _logger.LogInformation("user is not exist");
                    return null;
                }
                var passwordHash = PasswordHasher.ComputeHash(userDto.UserPassword, exisitingUser.PasswordSalt, _pepper, _iteration);
                if(exisitingUser.PasswordHash != passwordHash)
                {
                    _logger.LogInformation("user password didn't match");
                    return null;
                }
                _logger.LogInformation("login successfull");
                return exisitingUser;
            }
            catch (Exception ex)
            {
                _logger.LogError(default(EventId), ex, "loginUserAsync");
                throw;
            }
        }

        public async Task<Users> RegisterUserAsync(UserRegisterDto userdto)
        {
            try
            {
                var exisitingUser =  await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == userdto.UserEmail 
                                                   && u.UserMobile ==userdto.UserMobile);
                if(exisitingUser != null)
                {
                    _logger.LogInformation("user email/mobile is already exist");
                    return null;
                }

                var newUser = _mapper.Map<UserRegisterDto, Users>(userdto);

                newUser.PasswordSalt = PasswordHasher.GenerateSalt();
                newUser.PasswordHash = PasswordHasher.ComputeHash(userdto.Password, newUser.PasswordSalt , _pepper, _iteration);
                newUser.CreatedDateTime = DateTime.Now;
                newUser.UpdatedDateTime = DateTime.Now;
                newUser.IsEnabled = true;
                newUser.RoleId = Convert.ToInt32(Enums.Roles.SubAdmin);

                if (userdto.ProfileImage != null)
                {
                    string ProfileImgfolder = "Profile";

                    ProfileImgfolder += Guid.NewGuid().ToString().Substring(0, 5) + "_" + userdto.ProfileImage.FileName;
                    
                    string serverFilePath = Path.Combine(_environment.ContentRootPath, "CRMImages", ProfileImgfolder);
                    if (!Directory.Exists(Path.GetDirectoryName(serverFilePath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(serverFilePath));
                    }
                    using (var stream = new FileStream(serverFilePath, FileMode.Create))
                    {
                        userdto.ProfileImage.CopyTo(stream);
                    }
                    newUser.ProfilePicUrl = $"/CRMImages/{ProfileImgfolder}";
                }

                await _context.Users.AddAsync(newUser);
                await  _context.SaveChangesAsync();

                _logger.LogInformation("user is added successfully");

                return newUser;

            }
            catch (Exception ex)
            {
                _logger.LogError(default(EventId), ex, "RegisterUserAsync");
                throw;

            }
        }

        public Task<Users> UpdateUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
