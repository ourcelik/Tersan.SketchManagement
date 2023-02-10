using FluentValidation;

namespace Tersan.SketchManagement.Infrastructure.Validation.Common
{
    public class HexColorValidator : AbstractValidator<string?>
    {
        public HexColorValidator()
        {
            RuleFor(x => x).NotEmpty().WithMessage("Hexcolor is required")
                .MinimumLength(7).WithMessage("Length cannot be less than 7")
                .MaximumLength(7).WithMessage("Length cannot be more than 7")
                .Matches("^#(?:[0-9a-fA-F]{3}){1,2}$").WithMessage("Invalid HEX format");
        }
    }
}
