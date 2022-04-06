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
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(b => b.Content).NotEmpty().WithMessage(Messages.BlogContentEmpty);
            RuleFor(b => b.WriterId).NotEmpty().WithMessage("Writer " + Messages.NotFound);
            RuleFor(b => b.Title).NotEmpty().WithMessage(Messages.BlogTitleEmpty);
            RuleFor(b => b.Status).NotEmpty();
            RuleFor(b => b.Title).MaximumLength(50).WithMessage(Messages.BlogTitleTooLong);
            RuleFor(b => b.CreatedAt).NotEmpty();
        }
    }
}
