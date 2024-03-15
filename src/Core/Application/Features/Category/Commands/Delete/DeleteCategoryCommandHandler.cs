using Application.Contracts.Persistences;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, int>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository,
                                            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var findCategory = await _categoryRepository.GetByIdAsync(request.Id);

            if (findCategory is null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
                
            }
            await _categoryRepository.DeleteAsync(findCategory);
            return findCategory.Id;
        }
    }
}
