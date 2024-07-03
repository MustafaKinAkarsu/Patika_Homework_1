using FluentValidation;
using Patika_HW_1.Models;

namespace Patika_HW_1.Validations
{
	public class ProductValidator : AbstractValidator<Product>
	{
		public ProductValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
			RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
		}
	}
}
