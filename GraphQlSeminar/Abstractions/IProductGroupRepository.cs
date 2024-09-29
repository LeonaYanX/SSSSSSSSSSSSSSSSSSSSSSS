using GraphQlSeminar.Dto;

namespace GraphQlSeminar.Abstractions
{
    public interface IProductGroupRepository
    {
        IEnumerable<ProductGroupDto> GetAllProductGroups();
        int AddProductGroup(ProductGroupDto productGroupDto);

        void DeleteProductGroup(int id);
    }
}
