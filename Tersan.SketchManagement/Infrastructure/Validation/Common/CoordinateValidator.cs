using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Tersan.SketchManagement.Infrastructure.Validation.Common
{
    public class CoordinateValidator: AbstractValidator<int>
    {
        public CoordinateValidator()
        {
            RuleFor(x => x).NotEmpty().WithMessage("Position is required");
            RuleFor(x => x).GreaterThan(0).WithMessage("Position must be greater than 0");
        }
    }
}