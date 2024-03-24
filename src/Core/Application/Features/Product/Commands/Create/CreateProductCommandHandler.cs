using Application.Contracts.Persistences;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository,
                                            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator(_productRepository);
            var validationResult = validator.Validate(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Product Invalid", validationResult);
            }
            if (request != null)
            {
                await _productRepository.Product_AddAsync(request);
                return "Thêm thành công";
            }
            else
            {
                throw new NotFoundException(nameof(Product), request!);
            }
        }
    }
}
