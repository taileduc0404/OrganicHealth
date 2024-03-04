using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries.GetDetail
{
	//public class GetCategoryDetailQuery : IRequest<CategoryDetailDto>
	//{
	//}

	public record GetCategoryDetailQuery(int Id) : IRequest<CategoryDetailDto>;
}
