using Application.Contracts.Persistences;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Domain.Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository,
                                            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Domain.Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Product>(request);
            if(product != null) { 
                await _productRepository.CreateAsync(product);
                return product;
            }
            else
            {
                return null!;
            }
        }
    }
}
