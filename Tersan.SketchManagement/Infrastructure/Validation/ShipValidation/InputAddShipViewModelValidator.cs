using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Ship;
using Tersan.SketchManagement.Infrastructure.Validation.Common;

namespace Tersan.SketchManagement.Infrastructure.Validation.ShipValidation
{
    public class InputAddShipViewModelValidator: AbstractValidator<InputAddShipViewModel>
    {
        public InputAddShipViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.ShipStatusID).NotEmpty().WithMessage("ShipStatusID is required");
            RuleFor(x => x.X).SetValidator(new CoordinateValidator());
            RuleFor(x => x.Y).SetValidator(new CoordinateValidator());

            RuleFor(x => x.HexColorCode).SetValidator(new HexColorValidator());
        }
    }
}