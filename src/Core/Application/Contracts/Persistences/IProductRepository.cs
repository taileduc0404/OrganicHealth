using Application.Features.Product.Commands.Create;
using Application.Features.Product.Queries.GetAll;
using Domain;

namespace Application.Contracts.Persistences
{
	public interface IProductRepository : IGenericRepository<Product>
	{
        Task<IEnumerable<ProductDto>> GetAll();
        //Task<IEnumerable<ProductDto>> GetAll(ProductParams productParams);
        Task<bool> Product_AddAsync(CreateProductCommand dto);
        //Task<bool> AddAsync(AddProductDto dto);
        Task<bool> UpdateAsync(int id);
        //Task<bool> UpdateAsync(int id, UpdateProductDto dto);
        Task<bool> DeleteAsyncWithPicture(int id);
    }
}
