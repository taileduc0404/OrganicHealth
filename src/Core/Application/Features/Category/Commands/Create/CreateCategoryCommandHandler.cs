using Application.Contracts.Persistences;
using Application.Features.Category.Queries.GetAll;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository,
                                            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToCreate = _mapper.Map<Domain.Category>(request);
            if (categoryToCreate != null)
            {
                await _categoryRepository.CreateAsync(categoryToCreate);
                return categoryToCreate.Id;
            }
            else
            {
                return 0;
            }
        }
    }
}
