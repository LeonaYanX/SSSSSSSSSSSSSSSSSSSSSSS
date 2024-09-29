using AutoMapper;
using SSSSSSSSSSSSSSSSSSSSSSS.DbModels;
using SSSSSSSSSSSSSSSSSSSSSSS.Dto;

namespace SSSSSSSSSSSSSSSSSSSSSSS.Mapper
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
