using Business.BaseMessages;
using Entities.Concrete.TableModels.Membership;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class ApplicationUserValidation : AbstractValidator<ApplicationUser>
    {
        public ApplicationUserValidation()
        {
            RuleFor(x => x.Email)
            .NotEmpty()
               .WithMessage(UiMessages.NOT_EMPTY_MESSAGE)
              .MinimumLength(5)
            .MaximumLength(100)
              .WithMessage(UiMessages.MAXIMUM_100_SYMBOL_MESSAGE)
            .EmailAddress()
              .WithMessage(UiMessages.NOT_VALID_EMAIL);

            RuleFor(x => x.Name)
            .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE);
        }
    }
}
