using Application.Contracts.Persistences;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Queries.GetAll
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductRepository productRepository,
                                            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allProduct = await _productRepository.GetAsync();

                return _mapper.Map<List<ProductDto>>(allProduct);
            }
            catch (Exception) { throw; }

        }
    }
}
