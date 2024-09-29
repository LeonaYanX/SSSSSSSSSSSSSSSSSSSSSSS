using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using SSSSSSSSSSSSSSSSSSSSSSS.Abstractions;
using SSSSSSSSSSSSSSSSSSSSSSS.DbModels;
using SSSSSSSSSSSSSSSSSSSSSSS.Dto;

namespace SSSSSSSSSSSSSSSSSSSSSSS.Repository
{
    public class ProductRepository : IProductRepository
    {
        private  StorageDbContext _storageDbContext;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public ProductRepository(StorageDbContext storageDbContext ,IMapper mapper , IMemoryCache memoryCache)
        {
            _storageDbContext = storageDbContext;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        
        public int AddProduct(ProductDto productDto)
        {
            if (_storageDbContext.Products.Any(x => x.Name == productDto.Name)) throw new Exception("Product already exists");

            var product = _mapper.Map<Product>(productDto);

            _storageDbContext.Products.Add(product);
            _storageDbContext.SaveChanges();
            _memoryCache.Remove("products");

            return product.Id;
            
        }

      

        public IEnumerable<ProductDto> GetAllProducts()
        {
            if (_memoryCache.TryGetValue("products", out List<ProductDto>? productsDto)) return productsDto ?? new List<ProductDto>();
            var products = _storageDbContext.Products.ToList();
             productsDto = _mapper.Map<List<ProductDto>>(products);
            _memoryCache.Set("products", productsDto, TimeSpan.FromMinutes(30));
            return productsDto;
        }
    }
}
