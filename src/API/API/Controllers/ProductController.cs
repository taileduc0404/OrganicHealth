using Application.Contracts.Persistences;
using Application.Features.Product.Commands.Create;
using Application.Features.Product.Commands.Delete;
using Application.Features.Product.Commands.Update;
using Application.Features.Product.Queries.GetAll;
using Application.Features.Product.Queries.GetDetail;
using Application.Helpers;
using Application.Shared;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAll([FromQuery] ProductParams productParams)
        {
            //var response = await _mediator.Send(new GetAllProductQuery());
            var response = await _unitOfWork.ProductRepository.GetAll(productParams);
            var result = _mapper.Map<List<ProductDto>>(response);
            int total = result.Count;
            return Ok(new Pagination<ProductDto>(productParams.PageNumber, productParams.PageSize, total, result));
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
