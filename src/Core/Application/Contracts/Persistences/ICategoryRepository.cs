using Domain;

namespace Application.Contracts.Persistences
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Product>> GetCategoryListWithProductAsync(int categoryId);
        Task<List<Product>> GetCategoryDetailWithProductAsync(int categoryId);
    }
}
