using Application.Features.Product.Commands.Create;
using Application.Features.Product.Commands.Delete;
using Application.Features.Product.Commands.Update;
using Application.Features.Product.Queries.GetAll;
using Application.Features.Product.Queries.GetDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ProductDto>> GetAll()
        {
            var response = await _mediator.Send(new GetAllProductQuery());
            return response!;
        }

        [HttpGet]
        public async Task<ProductDetailDto> GetById([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetProductDetailQuery { Id = id });
            return response;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] CreateProductCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete] 
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            var response = await _mediator.Send(new DeleteProductCommand { ProductId = id });
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromForm] UpdateProductCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
