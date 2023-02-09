using FluentValidation;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Building;

namespace Tersan.SketchManagement.Infrastructure.Validation
{
    public class InputBuildingViewModelValidator: AbstractValidator<InputBuildingViewModel>
    {
        public InputBuildingViewModelValidator()
        {
            RuleFor(x => x.SketchId).NotEmpty().WithMessage("Sketch ID is required");
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0).WithMessage("Page index must be greater than or equal to 0");
            RuleFor(x => x.PageSize).NotEmpty().WithMessage("Page size is required");
        }
    }
}