using FluentValidation;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Building;

namespace Tersan.SketchManagement.Infrastructure.Validation
{
    public class InputBuildingViewModelValidator: AbstractValidator<InputBuildingViewModel>
    {
        public InputBuildingViewModelValidator()
        {
            RuleFor(x => x.SketchId).NotEmpty().WithMessage("Sketch ID is required");
            RuleFor(x => x.PageIndex).NotEmpty().WithMessage("Page index is required");
            RuleFor(x => x.PageSize).NotEmpty().WithMessage("Page size is required");
        }
    }
}