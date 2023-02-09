using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Sketch;

namespace Tersan.SketchManagement.Infrastructure.Validation.SketchValidation
{
    public class InputSketchCreateViewModelValidator : AbstractValidator<InputSketchCreateViewModel>
    {
        public InputSketchCreateViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}