using CustomerRelationshipManagementBackend.Data;
using CustomerRelationshipManagementBackend.Service.BillsServices;
using CustomerRelationshipManagementBackend.Service.ClientRequirementServices;
using CustomerRelationshipManagementBackend.Service.CompanyClientServices;
using CustomerRelationshipManagementBackend.Service.CompanyEmployeeServices;
using CustomerRelationshipManagementBackend.Service.CompanyUtilityServices;
using CustomerRelationshipManagementBackend.Service.CustomerComplaintQueryServices;
using CustomerRelationshipManagementBackend.Service.CustomerServices;
using CustomerRelationshipManagementBackend.Service.ProductServices;
using CustomerRelationshipManagementBackend.Service.ProjectsServices;
using CustomerRelationshipManagementBackend.Service.PurchaseServices;
using CustomerRelationshipManagementBackend.Service.SuppliersServices;
using CustomerRelationshipManagementBackend.Service.TaskSchedulerServices;
using CustomerRelationshipManagementBackend.Service.UserServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(cors => cors.AddPolicy("MyPolicy", builder => {
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddTransient<IUserService, Userservice>();
builder.Services.AddTransient<ISupplierService, SupplierService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IPurchaseService, PurchaseService>();
builder.Services.AddTransient<IBillsService, BillsService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICompanyClientservice, CompanyClientservice>();
builder.Services.AddTransient<ICompanyUtilityService, CompanyUtilityService>();
builder.Services.AddTransient<ICompanyEmployeeService, CompanyEmployeeService>();
builder.Services.AddTransient<IClientRequirementService, ClientRequirementService>();
builder.Services.AddTransient<ITaskSchedulerService, TaskSchedulerService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<ICustomerComplaintQueryService, CustomerComplaintQueryService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IWebHostEnvironment>(builder.Environment);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "CRMImages")),
    RequestPath = "/CRMImages"
});

app.UseCors("MyPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
