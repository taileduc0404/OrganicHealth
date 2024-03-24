using MediatR;

namespace Application.Features.Product.Queries.GetDetail
{
    public class GetProductDetailQuery : IRequest<ProductDetailDto>
    {
        public int Id { get; set; }
    }
}
