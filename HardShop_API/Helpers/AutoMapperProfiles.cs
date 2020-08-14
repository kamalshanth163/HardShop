using AutoMapper;
using HardShop_API.Dtos;
using HardShop_API.Models;

namespace HardShop_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CustomerRegisterDto, Customer>();
            CreateMap<AdminRegisterDto, Admin>();
        }
    }
}