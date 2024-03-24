using Application.Features.Category.Commands.Create;
using Application.Features.Category.Commands.Delete;
using Application.Features.Category.Commands.Update;
using Application.Features.Category.Queries.GetAll;
using Application.Features.Category.Queries.GetDetail;
using MediatR;
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
        public async Task<ActionResult<CategoryDetailDto>> GetById([FromQuery] int id)
        {
            var category = await _mediator.Send(new GetCategoryDetailQuery(id));
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] DeleteCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
