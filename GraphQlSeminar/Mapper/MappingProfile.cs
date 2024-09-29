using AutoMapper;
using GraphQlSeminar.DbModels;
using GraphQlSeminar.Dto;

namespace GraphQlSeminar.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<ProductGroup,ProductGroupDto>().ReverseMap();
            CreateMap<Storage,StorageDto>().ReverseMap();
        }
    }
}
