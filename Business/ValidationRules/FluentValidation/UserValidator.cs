using Business.Constants;
using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage(Messages.UserFirstNameEmpty);
            RuleFor(u => u.LastName).NotEmpty().WithMessage(Messages.UserLastNameEmpty);
            RuleFor(u => u.Email).NotEmpty().WithMessage(Messages.UserEmailEmpty);
            RuleFor(u => u.PasswordHash).NotEmpty().WithMessage(Messages.UserPasswordError);
            RuleFor(u => u.PasswordSalt).NotEmpty().WithMessage(Messages.UserPasswordError);
            RuleFor(u => u.FirstName).MaximumLength(50).WithMessage(Messages.FirstNameTooLong);
            RuleFor(u => u.LastName).MaximumLength(50).WithMessage(Messages.LastNameTooLong);
        }
    }
}
