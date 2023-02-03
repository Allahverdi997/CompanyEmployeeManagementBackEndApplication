using FluentValidation;
using RusMProjectApplication.Messages;
using RusMProjectApplication.Registration.CreateDSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Validations.CreateValidator
{
    public class UserValidator : AbstractValidator<UserDSO>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationMessage.NotEmpty);
            RuleFor(x => x.Name).MinimumLength(2).WithMessage(ValidationMessage.MinimumLengthTwo);

            RuleFor(x => x.Surname).NotEmpty().WithMessage(ValidationMessage.NotEmpty);
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage(ValidationMessage.MinimumLengthTwo);

            RuleFor(x => x.Patronymic).NotEmpty().WithMessage(ValidationMessage.NotEmpty);
            RuleFor(x => x.Patronymic).MinimumLength(2).WithMessage(ValidationMessage.MinimumLengthTwo);

            RuleFor(x => x.Password).NotEmpty().WithMessage(ValidationMessage.NotEmpty);
            RuleFor(x => x.Password).MinimumLength(2).WithMessage(ValidationMessage.MinimumLengthTwo);
        }
    }
}
