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
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(Messages.CategoryNameEmpty);
            RuleFor(c => c.Description).NotEmpty().WithMessage(Messages.CategoryDescriptionEmpty);
            RuleFor(c => c.Status).NotEmpty();
            RuleFor(c => c.Description).MaximumLength(150).WithMessage(Messages.CategoryDescriptionTooLong);
            RuleFor(c => c.Name).MaximumLength(30).WithMessage(Messages.CategoryNameTooLong);
        }
    }
}
