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
    public class AdressValidation : AbstractValidator<Adress>
    {
        public AdressValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE)
                .MaximumLength(50)
                .WithMessage(UiMessages.MAXIMUM_50_SYMBOL_MESSAGE)
                .MinimumLength(11)
                .WithMessage(UiMessages.MINIMUM_11_SYMBOL_MESSAGE);

            RuleFor(x => x.Location)
                .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE)
                .MaximumLength(100)
                .WithMessage(UiMessages.MAXIMUM_100_SYMBOL_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE);

            RuleFor(x => x.Phone1)
                .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE)
                .MaximumLength(13)
                .WithMessage(UiMessages.MAXIMUM_50_SYMBOL_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE);

            RuleFor(x => x.Phone2)
                .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE)
                .MaximumLength(13)
                .WithMessage(UiMessages.MAXIMUM_50_SYMBOL_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE);

            RuleFor(x => x.Phone3)
                .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE)
                .MaximumLength(13)
                .WithMessage(UiMessages.MAXIMUM_50_SYMBOL_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE);
        }
    }
}
