using FluentValidation;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Building;
using Tersan.SketchManagement.Infrastructure.Validation.Common;

namespace Tersan.SketchManagement.Infrastructure.Validation
{
    public class InputAddBuildingViewModelValidator: AbstractValidator<InputAddBuildingViewModel>
    {
        public InputAddBuildingViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Building name is required");
            RuleFor(x => x.SketchId).NotEmpty().WithMessage("Sketch ID is required");
            RuleFor(x => x.HexColorCode).NotEmpty().WithMessage("Hexcolor is required")
                .MinimumLength(7).WithMessage("Length cannot be less than 7")
                .MaximumLength(7).WithMessage("Length cannot be more than 7")
                .Matches("^#(?:[0-9a-fA-F]{3}){1,2}$").WithMessage("Invalid HEX format");
           
            RuleFor(x => x.X).SetValidator(new CoordinateValidator());
            RuleFor(x => x.Y).SetValidator(new CoordinateValidator());

        }
    }
}