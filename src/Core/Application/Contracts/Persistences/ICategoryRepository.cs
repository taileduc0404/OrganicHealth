using Domain;

namespace Application.Contracts.Persistences
{
	public interface ICategoryRepository : IGenericRepository<Category>
	{
        Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId);
    }
}
