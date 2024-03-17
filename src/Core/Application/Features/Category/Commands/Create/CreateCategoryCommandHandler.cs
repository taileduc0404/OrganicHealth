using Application.Contracts.Persistences;
using Application.Exceptions;
using AutoMapper;
using MediatR;

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
            var validator = new CreateCategoryCommandValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Category.", validationResult);
            }
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
