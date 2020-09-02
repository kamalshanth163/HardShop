using AutoMapper;
using HardShop_API.Dtos;
using HardShop_API.Models;

namespace HardShop_API.Helpers {
    public class AutoMapperProfiles : Profile {
        public AutoMapperProfiles () {
            CreateMap<CustomerRegisterDto, Customer> ();
            CreateMap<AdminRegisterDto, Admin> ();
            CreateMap<PhoneCreateDto, Phone> ();
            CreateMap<ProductOptionCreateDto, ProductOption> ();
            CreateMap<ProductCreateDto, Product> ();
            CreateMap<ProductCreateDetailDto, ProductCreateDto> ();
            CreateMap<ProductReviewCreateDto, ProductReview> ();
            CreateMap<ProductCreateDto, ProductOption> ();
            CreateMap<ProductMainCategoryCreateDto, ProductMainCategory> ();
            CreateMap<ProductSubCategoryCreateDto, ProductSubCategory> ();
            CreateMap<ProductSubCategoryCreateDetailDto, ProductSubCategoryCreateDto> ();

        }
    }
}