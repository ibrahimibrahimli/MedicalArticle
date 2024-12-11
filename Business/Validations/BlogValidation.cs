using Business.BaseMessages;
using Entities.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class BlogValidation : AbstractValidator<Blog>
    {
        public BlogValidation()
        {
            RuleFor(x => x.Text)
              .MinimumLength(3)
              .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
              .MaximumLength(3000)
              .WithMessage(UiMessages.MAXIMUM_3000_SYMBOL_MESSAGE)
              .NotEmpty()
              .WithMessage(UiMessages.NOT_EMPTY_MESSAGE);

            RuleFor(x => x.Title)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(1000)
                .WithMessage(UiMessages.MAXIMUM_1000_SYMBOL_MESSAGE)
                .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE);
        }
    }
}
