using Microsoft.AspNetCore.Mvc;
using SSSSSSSSSSSSSSSSSSSSSSS.Abstractions;
using SSSSSSSSSSSSSSSSSSSSSSS.DbModels;
using SSSSSSSSSSSSSSSSSSSSSSS.Dto;

namespace SSSSSSSSSSSSSSSSSSSSSSS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)=> _productRepository = productRepository;

        [HttpPost(template: "AddProduct")]
        public ActionResult<int> AddProduct(ProductDto productDto)
        {
            try
            {
               
                return Ok(_productRepository.AddProduct(productDto));
            }
            catch 
            {
            return StatusCode(409);
            }
          
          
        }
        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts() 
        {
            try 
            {
                return Ok(_productRepository.GetAllProducts());
            }
            catch 
            {
                return StatusCode(500);
            }
            
        }
    }
}
