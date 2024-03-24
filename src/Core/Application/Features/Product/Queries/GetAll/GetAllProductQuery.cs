using MediatR;

namespace Application.Features.Product.Queries.GetAll
{
    public record GetAllProductQuery() : IRequest<List<ProductDto>>;
}
