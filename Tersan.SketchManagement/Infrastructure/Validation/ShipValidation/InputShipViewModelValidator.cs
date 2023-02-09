using FluentValidation;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Ship;

namespace Tersan.SketchManagement.Infrastructure.Validation.ShipValidation
{
    public class InputShipViewModelValidator : AbstractValidator<InputShipViewModel>
    {
        public InputShipViewModelValidator()
        {
            RuleFor(x => x.PageSize).NotEmpty().WithMessage("PageSize is required");
            RuleFor(x => x.PageIndex).NotEmpty().WithMessage("PageIndex is required");
            RuleFor(x => x.SketchId).NotEmpty().WithMessage("SketchId is required");
        }
    }
}