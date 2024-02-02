using CustomerRelationshipManagementBackend.Model;
using CustomerRelationshipManagementBackend.ModelDto;

namespace CustomerRelationshipManagementBackend.Service.UserServices
{
    public interface IUserService
    {
        public Task<Users> RegisterUserAsync(UserRegisterDto userDto);
        public Task<Users> loginUserAsync(UserLoginDto user);
        public Task<Users> GetUserAsync(int userId);
        public Task<IList<Users>> GetAllUserByFilter(int page, int pageSize, string? search);
        public Task<Users> UpdateUsersAsync();
    }
}
