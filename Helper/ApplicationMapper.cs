using AutoMapper;
using CustomerRelationshipManagementBackend.Model;
using CustomerRelationshipManagementBackend.ModelDto;

namespace CustomerRelationshipManagementBackend.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<Users, UserRegisterDto>().ReverseMap();
            CreateMap<Users, UpdateuserDto>().ReverseMap();
            CreateMap<Suppliers, AddSupplierDto>().ReverseMap();
            CreateMap<Suppliers, UpdateSupplierDto>().ReverseMap();
            CreateMap<TasksScheduler , AddTaskSchedulerDto>().ReverseMap();
            CreateMap<Products , AddProductDto>().ReverseMap();
            CreateMap<Products, UpdateProductDto>().ReverseMap();
        }
    }
}
