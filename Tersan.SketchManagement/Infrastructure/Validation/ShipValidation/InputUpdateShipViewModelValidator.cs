using FluentValidation;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Ship;
using Tersan.SketchManagement.Infrastructure.Validation.Common;

namespace Tersan.SketchManagement.Infrastructure.Validation.ShipValidation
{
    public class InputUpdateShipViewModelValidator : AbstractValidator<InputUpdateShipViewModel>
    {
        public InputUpdateShipViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.ShipStatusType).NotEmpty().WithMessage("ShipStatusID is required");
            RuleFor(x => x.X).SetValidator(new CoordinateValidator());
            RuleFor(x => x.Y).SetValidator(new CoordinateValidator());
            RuleFor(x => x.Width).SetValidator(new CoordinateValidator());
            RuleFor(x => x.Height).SetValidator(new CoordinateValidator());
            RuleFor(x => x.HexColorCode).SetValidator(new HexColorValidator());
        }
    }
}