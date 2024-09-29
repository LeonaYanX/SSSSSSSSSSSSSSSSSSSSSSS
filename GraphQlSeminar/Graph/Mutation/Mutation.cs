using GraphQlSeminar.Abstractions;
using GraphQlSeminar.Dto;

namespace GraphQlSeminar.Graph.Mutation
{
    public class Mutation
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IStorageRepository _storageRepository;
        public Mutation(IProductGroupRepository productGroupRepository, IStorageRepository storageRepository, IProductRepository productRepository)
        {
           _productGroupRepository = productGroupRepository;
           _productRepository = productRepository;
           _storageRepository = storageRepository;
        }
        public int AddProduct(ProductDto productDto) => _productRepository.AddProduct(productDto);

        public int AddProductGroup(ProductGroupDto productGroupDto) => _productGroupRepository.AddProductGroup(productGroupDto);

        public int AddStorage(StorageDto storageDto) => _storageRepository.AddStorage(storageDto);
    }
}
