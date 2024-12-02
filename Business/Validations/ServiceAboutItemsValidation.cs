using Business.BaseMessages;
using Entities.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class ServiceAboutItemsValidation : AbstractValidator<ServiceAboutItemDto>
    {
        public ServiceAboutItemsValidation()
        {
            RuleFor(x => x.Text)
               .MinimumLength(3)
               .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
               .MaximumLength(300)
               .WithMessage(UiMessages.MAXIMUM_300_SYMBOL_MESSAGE)
               .NotEmpty()
               .WithMessage(UiMessages.NOT_EMPTY_MESSAGE);
        }
    }
}
