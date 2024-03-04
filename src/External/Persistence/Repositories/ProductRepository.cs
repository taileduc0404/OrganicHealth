using Application.Contracts.Persistences;
using Domain;
using Persistence.Context;

namespace Persistence.Repositories
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
