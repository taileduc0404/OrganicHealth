using Application.Contracts.Persistences;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetDetail
{
    public class GetCategoryDetailQueryHandler : IRequestHandler<GetCategoryDetailQuery, CategoryDetailDto>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryDetailQueryHandler(ICategoryRepository categoryRepository,
                                            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDetailDto> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category is not null)
            {

                return _mapper.Map<CategoryDetailDto>(category);
            }
            throw new NotFoundException(nameof(Category), request.Id);
        }
    }
}
