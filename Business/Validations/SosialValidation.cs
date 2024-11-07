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
    public class SosialValidation : AbstractValidator<Sosial>
    {
        public SosialValidation()
        {
            RuleFor(x => x.FacebookUrl)
            .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
            .MaximumLength(200)
                .WithMessage(UiMessages.MAXIMUM_200_SYMBOL_MESSAGE);

            RuleFor(x => x.WhatsappUrl)
            .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
            .MaximumLength(200)
                .WithMessage(UiMessages.MAXIMUM_200_SYMBOL_MESSAGE);


            RuleFor(x => x.InstagramUrl)
            .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
            .MaximumLength(200)
                .WithMessage(UiMessages.MAXIMUM_200_SYMBOL_MESSAGE);

            RuleFor(x => x.Telegram)
            .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
            .MaximumLength(200)
                .WithMessage(UiMessages.MAXIMUM_200_SYMBOL_MESSAGE);


            RuleFor(x => x.TwitterUrl)
            .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
            .MaximumLength(200)
                .WithMessage(UiMessages.MAXIMUM_200_SYMBOL_MESSAGE);
        }
    }
}
