using FluentValidation;
using RusMProject.Domain.Common;
using RusMProjectApplication.Abstraction;
using RusMProjectApplication.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Validations
{
    public class GeneralUpdateValidator<T>:AbstractValidator<T> where T:IUpdateDSOAble
    {
        public GeneralUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationMessage.NotEmpty);
        }
    }
}
