using Application.Contracts.Persistences;
using FluentValidation;

namespace Application.Features.Product.Commands.Update
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandValidator(IProductRepository productRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} phải nhỏ hơn 50 ký tự.")
                .MinimumLength(5).WithMessage("{PropertyName} phải lớn hơn 5 ký tự.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} phải nhỏ hơn 50 ký tự.")
                .MinimumLength(5).WithMessage("{PropertyName} phải lớn hơn 5 ký tự.");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(1000).WithMessage("{PropertyName} phải lớn hơn 1000")
                .LessThanOrEqualTo(100000).WithMessage("{PropertyName} phải nhỏ hơn hoặc bằng 100000");


            _productRepository = productRepository;
        }
    }
}
