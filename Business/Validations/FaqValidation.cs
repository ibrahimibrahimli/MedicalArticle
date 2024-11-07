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
    public class FaqValidation : AbstractValidator<Faq>
    {
        public FaqValidation()
        {
            RuleFor(x => x.Question)
            .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE)
            .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
            .MaximumLength(200)
                .WithMessage(UiMessages.MAXIMUM_200_SYMBOL_MESSAGE);

            RuleFor(x => x.Answer)
            .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(10000)
                .WithMessage(UiMessages.MAXIMUM_1000_SYMBOL_MESSAGE);
        }
    }
}
