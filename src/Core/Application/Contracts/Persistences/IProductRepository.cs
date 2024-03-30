using Application.Features.Product.Commands.Create;
using Application.Features.Product.Commands.Update;
using Application.Features.Product.Queries.GetAll;
using Application.Shared;
using Domain;

namespace Application.Contracts.Persistences
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<ProductDto>> GetAll(ProductParams productParams);
        //Task<IEnumerable<ProductDto>> GetAll(ProductParams productParams);
        Task<bool> Product_AddAsync(CreateProductCommand dto);
        //Task<bool> AddAsync(AddProductDto dto);
        Task<bool> UpdateProductWithImageAsync(int id, UpdateProductCommand dto);
        //Task<bool> UpdateAsync(int id, UpdateProductDto dto);
        //Task<bool> DeleteAsyncWithPicture(int id);
    }
}
