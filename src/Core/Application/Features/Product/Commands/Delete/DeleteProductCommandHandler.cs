using Application.Contracts.Persistences;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, string>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository,
                                            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var productFind = await _productRepository.GetByIdAsync(request.ProductId);
                if (productFind != null)
                {
                    await _productRepository.DeleteAsync(productFind);
                    return "Xóa thành công";
                }
                else
                {
                    return "Xóa không thành công";
                }
            }
            catch (Exception) { throw; }
        }
    }
}
