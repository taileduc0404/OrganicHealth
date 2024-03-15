using MediatR;

namespace Application.Features.Product.Commands.Delete
{
    public class DeleteProductCommand : IRequest<string>
    {
        public int ProductId { get; set; }
    }
}
