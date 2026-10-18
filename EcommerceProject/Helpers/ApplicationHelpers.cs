using AutoMapper;
using EcommerceProject.DTO;
using EcommerceProject.Models;

namespace EcommerceProject.Helpers
{
    public class ApplicationHelpers:Profile
    {
        public ApplicationHelpers()
        {
            CreateMap<CustomersModel, CustomersDto>();
        }
    }
}
