using Business.BaseMessages;
using Entities.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(50)
                .WithMessage(UiMessages.MAXIMUM_50_SYMBOL_MESSAGE);

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(50)
                .WithMessage(UiMessages.MAXIMUM_50_SYMBOL_MESSAGE)
                .EmailAddress()
                .WithMessage(UiMessages.NOT_VALID_EMAIL);

            RuleFor(x => x.Message)
                .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(200)
                .WithMessage(UiMessages.MAXIMUM_2000_SYMBOL_MESSAGE);
        }
    }
}
