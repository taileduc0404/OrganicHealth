using Application.Features.Category.Queries.GetAll;
using Application.Features.Category.Queries.GetDetail;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CategoryController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<List<CategoryDto>> GetAll()
		{
			var allCategory = await _mediator.Send(new GetAllCategoryQuery());
			return allCategory;
		}


		[HttpGet]
		public async Task<ActionResult<CategoryDetailDto>> GetById(int id)
		{
			var category = await _mediator.Send(new GetCategoryDetailQuery(id));
			return Ok(category);
		}
	}
}
