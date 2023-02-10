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
           
            RuleFor(x => x.X).SetValidator(new CoordinateValidator());
            RuleFor(x => x.Y).SetValidator(new CoordinateValidator());

            RuleFor(x => x.HexColorCode).SetValidator(new HexColorValidator());

        }
    }
}