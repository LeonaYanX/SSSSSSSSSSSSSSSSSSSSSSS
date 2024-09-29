using GraphQlSeminar.Abstractions;
using GraphQlSeminar.Dto;

namespace GraphQlSeminar.Graph.Query
{
    public class Query
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IStorageRepository _storageRepository;
        public Query(IProductRepository productRepository , IProductGroupRepository productGroupRepository, IStorageRepository storageRepository)
        {
            _productRepository = productRepository;
            _productGroupRepository = productGroupRepository;
            _storageRepository = storageRepository;
        }
        public IEnumerable<StorageDto> GetStorages() 
        {
        return _storageRepository.GetAllStorages();
        }
        public IEnumerable<ProductDto> GetProducts() 
        {
           return _productRepository.GetAllProducts();
        }

        public IEnumerable<ProductGroupDto> GetProductGroups() 
        {
          return _productGroupRepository.GetAllProductGroups();
        }
    }
}
