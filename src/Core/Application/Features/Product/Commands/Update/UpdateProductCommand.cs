using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Product.Commands.Update
{
    public class UpdateProductCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile? ProductPicture { get; set; }
        public int CategoryId { get; set; }
    }
}
