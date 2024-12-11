using Business.BaseMessages;
using Entities.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class FactValidation : AbstractValidator<Fact>
    {
        public FactValidation()
        {
            RuleFor(x => x.Title)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(3000)
                .WithMessage(UiMessages.MAXIMUM_3000_SYMBOL_MESSAGE)
                .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE);

            RuleFor(x => x.IconUrl)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(200)
                .WithMessage(UiMessages.MAXIMUM_200_SYMBOL_MESSAGE)
                .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE);
        }
    }
}
