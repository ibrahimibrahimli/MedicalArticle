using Business.BaseMessages;
using Entities.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class WhyChooseUsValidation : AbstractValidator<WhyChooseUs>
    {
        public WhyChooseUsValidation()
        {
            RuleFor(x => x.Description)
             .MinimumLength(3)
             .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
             .MaximumLength(3000)
             .WithMessage(UiMessages.MAXIMUM_3000_SYMBOL_MESSAGE)
             .NotEmpty()
             .WithMessage(UiMessages.NOT_EMPTY_MESSAGE);
        }
    }
}
