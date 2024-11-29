using Business.BaseMessages;
using Entities.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class HealtTipValidation : AbstractValidator<HealtTip>
    {
        public HealtTipValidation()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(50)
                .WithMessage(UiMessages.MAXIMUM_50_SYMBOL_MESSAGE)
                .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE);

            RuleFor(x => x.Surname)
               .MinimumLength(3)
               .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
               .MaximumLength(50)
               .WithMessage(UiMessages.MAXIMUM_50_SYMBOL_MESSAGE)
               .NotEmpty()
               .WithMessage(UiMessages.NOT_EMPTY_MESSAGE);

            RuleFor(x => x.Header)
               .MinimumLength(3)
               .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
               .MaximumLength(300)
               .WithMessage(UiMessages.MAXIMUM_300_SYMBOL_MESSAGE)
               .NotEmpty()
               .WithMessage(UiMessages.NOT_EMPTY_MESSAGE);

            RuleFor(x => x.Title)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(300)
                .WithMessage(UiMessages.MAXIMUM_300_SYMBOL_MESSAGE)
                .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE);

            RuleFor(x => x.Description)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(1000)
                .WithMessage(UiMessages.MAXIMUM_1000_SYMBOL_MESSAGE)
                .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE);

            RuleFor(x => x.SubTitle)
               .MinimumLength(3)
               .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
               .MaximumLength(300)
               .WithMessage(UiMessages.MAXIMUM_300_SYMBOL_MESSAGE)
               .NotEmpty()
               .WithMessage(UiMessages.NOT_EMPTY_MESSAGE);
        }
    }
}
