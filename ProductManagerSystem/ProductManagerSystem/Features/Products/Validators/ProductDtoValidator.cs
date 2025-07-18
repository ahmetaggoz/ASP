using FluentValidation;
using ProductManagerSystem.Features.Products.Dtos;

namespace ProductManagerSystem.Features.Products.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(X => X.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MinimumLength(2).WithMessage("Ürün adı en az 2 harf olmalı.");
            RuleFor(X => X.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }
}
