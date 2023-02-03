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
    public class DepartmentValidator:AbstractValidator<DepartmentDSO>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationMessage.NotEmpty);
            RuleFor(x => x.Name).MinimumLength(2).WithMessage(ValidationMessage.MinimumLengthTwo);
        }
    }
}
