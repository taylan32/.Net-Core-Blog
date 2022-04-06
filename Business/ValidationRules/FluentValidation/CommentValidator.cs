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
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(c => c.BlogId).NotEmpty().WithMessage("Blog " + Messages.NotFound);
            RuleFor(c => c.WriterId).NotEmpty().WithMessage("Writer " + Messages.NotFound);
            RuleFor(c => c.CreatedAt).NotEmpty();
            RuleFor(c => c.Content).NotEmpty().WithMessage(Messages.CommentEmpty);
            RuleFor(c => c.Title).NotEmpty().WithMessage(Messages.CommentTitleEmpty);
            RuleFor(c => c.Content).MaximumLength(200).WithMessage(Messages.CommentTooLong);
            RuleFor(c => c.Title).MaximumLength(50).WithMessage(Messages.CommentTitleTooLong);
        }
    }
}
