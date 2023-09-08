using AutoMapper;
using Product.Models;
using Product.Models.DTO;

namespace Product.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Products, ProductDTO>().ReverseMap();
            CreateMap<Products, CreateProductDTO>().ReverseMap();
            CreateMap<Products, UpdateProductDTO>().ReverseMap();

        }
    }
}
