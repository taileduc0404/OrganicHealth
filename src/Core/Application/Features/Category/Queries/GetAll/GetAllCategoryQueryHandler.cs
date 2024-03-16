using Application.Contracts.Persistences;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries.GetAll
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository,
                                            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var allCategory = await _categoryRepository.GetAsync();
            if (allCategory is not null)
            {

                var categoryDtos = _mapper.Map<List<CategoryDto>>(allCategory);


                foreach (var category in categoryDtos)
                {
                    var products = await _categoryRepository.GetProductsByCategoryIdAsync(category.Id);

                    category.Products = products.Any() == true ? products.ToList() : null!;
                }

                return categoryDtos;
            }
            throw new NotFoundException(nameof(Category), request);
        }
    }
}
