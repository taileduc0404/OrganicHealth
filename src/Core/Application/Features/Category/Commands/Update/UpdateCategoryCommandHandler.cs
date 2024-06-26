﻿using Application.Contracts.Persistences;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCategoryCommandValidator(_categoryRepository);
            var validationResult = validator.Validate(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Category Invalid", validationResult);
            }

            var findCategory = await _categoryRepository.GetByIdAsync(request.Id);
            if (findCategory != null)
            {
                var res = _mapper.Map<Domain.Category>(request);
                await _categoryRepository.UpdateAsync(res);
                return Unit.Value;
            }
            else
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }
        }
    }
}
