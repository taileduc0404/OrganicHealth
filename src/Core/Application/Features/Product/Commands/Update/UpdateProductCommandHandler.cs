﻿using Application.Contracts.Persistences;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, string>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository,
                                            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var productFind = await _productRepository.GetByIdAsync(request.Id);
                if (productFind != null)
                {
                    await _productRepository.UpdateProductWithImageAsync(request.Id, request);
                    return "Cập nhật thành công";
                }
                else
                {
                    return "Cập nhật không thành công";
                }
            }
            catch (Exception) { throw; }

        }
    }
}
