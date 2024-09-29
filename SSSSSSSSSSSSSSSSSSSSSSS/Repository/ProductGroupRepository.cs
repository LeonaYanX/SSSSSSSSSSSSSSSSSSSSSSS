using AutoMapper;
using SSSSSSSSSSSSSSSSSSSSSSS.Abstractions;
using SSSSSSSSSSSSSSSSSSSSSSS.DbModels;
using SSSSSSSSSSSSSSSSSSSSSSS.Dto;

namespace SSSSSSSSSSSSSSSSSSSSSSS.Repository
{
    public class ProductGroupRepository:IProductGroupRepository
    {
        private StorageDbContext _storageDbContext;
        private readonly IMapper _mapper;

        public ProductGroupRepository(StorageDbContext storageDbContext, IMapper mapper) 
        {
           _storageDbContext = storageDbContext;
           _mapper = mapper;
        }

        public IEnumerable<ProductGroupDto> GetAllProductGroups()
        {
              var productGroups = _storageDbContext.ProductGroups.ToList();
              var productGroupsDto = _mapper.Map<List<ProductGroupDto>>(productGroups);
            return productGroupsDto;
        }

        public int AddProductGroup(ProductGroupDto productGroupDto)
        {
            if (_storageDbContext.ProductGroups.Any(x => x.Name == productGroupDto.Name)) throw new Exception("ProductGroup already exists");

            var productGroup = _mapper.Map<ProductGroup>(productGroupDto);
            _storageDbContext.ProductGroups.Add(productGroup);
            _storageDbContext.SaveChanges();

            return productGroup.Id;
        }

        public void DeleteProductGroup(int id)
        {
            throw new NotImplementedException();
        }
    }
}
