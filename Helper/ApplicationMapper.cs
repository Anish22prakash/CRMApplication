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
            CreateMap<Suppliers, AddSupplierDto>().ReverseMap();
        }
    }
}
