using GraphQlSeminar.DbModels;
using GraphQlSeminar.Dto;

namespace GraphQlSeminar.Abstractions
{
    public interface IProductRepository
    {
        IEnumerable<ProductDto> GetAllProducts();

        int AddProduct(ProductDto productDto);

       
    }
}
