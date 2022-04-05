using Business.Constants;
using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w => w.UserId).NotEmpty().WithMessage("User " + Messages.NotFound);
            RuleFor(w => w.About).NotEmpty().WithMessage(Messages.AboutEmpty);
            RuleFor(w => w.About).MaximumLength(400).WithMessage(Messages.AboutTooLong);
        }
    }
}
