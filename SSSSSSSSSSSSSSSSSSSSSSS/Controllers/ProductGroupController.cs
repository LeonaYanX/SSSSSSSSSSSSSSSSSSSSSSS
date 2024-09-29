using Microsoft.AspNetCore.Mvc;
using SSSSSSSSSSSSSSSSSSSSSSS.Abstractions;
using SSSSSSSSSSSSSSSSSSSSSSS.Dto;

namespace SSSSSSSSSSSSSSSSSSSSSSS.Controllers
{
    public class ProductGroupController : ControllerBase
    {
       private IProductGroupRepository _productGroupRepository;

        public ProductGroupController(IProductGroupRepository productGroupRepository)=> _productGroupRepository = productGroupRepository;


        [HttpGet(template: "GetAllProductGroups")]
        public ActionResult<List<ProductGroupDto>> GetAllProductGroups()
        {
            try
            {
                return Ok(_productGroupRepository.GetAllProductGroups());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost(template: "AddProductGroup")]
        public ActionResult<int> AddProductGroup(ProductGroupDto productGroupDto) 
        {
            try 
            {

            return Ok(_productGroupRepository.AddProductGroup(productGroupDto));
            }
            catch { return StatusCode(409); }
        }

/*        [HttpDelete(template: "DeleteProductGroup/{id}")]
        public ActionResult<int> DeleteProductGroup(int id) 
        {
        
        }*/
    }
}
