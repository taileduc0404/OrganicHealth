using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands.Create
{
    public class CreateProductCommand : IRequest<string>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile? ProductPicture { get; set; }
        public int CategoryId { get; set; }
    }
}
