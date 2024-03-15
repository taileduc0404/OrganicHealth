using Application.Contracts.Persistences;
using FluentValidation;

namespace Application.Features.Category.Commands.Update
{
    public class UpdateCategoryCommandValidator:AbstractValidator<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandValidator(ICategoryRepository categoryRepository) {
            RuleFor(x => x.Name)
                   .NotEmpty().WithMessage("{PropertyName} is required.")
                   .NotNull()
                   .MaximumLength(30).WithMessage("{PropertyName} phải nhỏ hơn 30 ký tự.")
                   .MinimumLength(3).WithMessage("{PropertyName} phải lớn hơn 3 ký tự.");
            _categoryRepository = categoryRepository;
        }
    }
}
