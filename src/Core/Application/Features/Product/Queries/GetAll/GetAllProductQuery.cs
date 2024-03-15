using Application.Features.Category.Queries.GetDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Queries.GetAll
{
    public record GetAllProductQuery() : IRequest<List<ProductDto>>;
}
