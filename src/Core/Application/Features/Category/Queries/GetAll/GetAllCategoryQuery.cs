using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries.GetAll
{
	public record GetAllCategoryQuery : IRequest<List<CategoryDto>>;
}
