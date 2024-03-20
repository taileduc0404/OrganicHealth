using Application.Features.Product.Queries.GetAll;
using Domain;

namespace Application.Contracts.Persistences
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<ProductDto>> GetCategoryListWithProductAsync(int categoryId);
        Task<List<Product>> GetCategoryDetailWithProductAsync(int categoryId);
    }
}
