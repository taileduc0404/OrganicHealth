using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands.Create
{
    public class CreateProductCommand : IRequest<Domain.Product>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ProductPicture { get; set; }
        public int CategoryId { get; set; }
    }
}
