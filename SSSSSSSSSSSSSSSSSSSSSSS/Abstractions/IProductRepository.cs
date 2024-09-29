using SSSSSSSSSSSSSSSSSSSSSSS.DbModels;
using SSSSSSSSSSSSSSSSSSSSSSS.Dto;

namespace SSSSSSSSSSSSSSSSSSSSSSS.Abstractions
{
    public interface IProductRepository
    {
        IEnumerable<ProductDto> GetAllProducts();

        int AddProduct(ProductDto productDto);

       
    }
}
