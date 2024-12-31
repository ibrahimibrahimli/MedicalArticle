using Business.BaseMessages;
using Entities.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class CommentValidation :AbstractValidator<Comment>
    {
        public CommentValidation()
        {
            RuleFor(x => x.UserName).NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(50)
                .WithMessage(UiMessages.MAXIMUM_50_SYMBOL_MESSAGE);

            RuleFor(x => x.UserSurname).NotEmpty()
               .WithMessage(UiMessages.NOT_EMPTY_MESSAGE)
               .MinimumLength(3)
               .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
               .MaximumLength(50)
               .WithMessage(UiMessages.MAXIMUM_50_SYMBOL_MESSAGE);

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(2000)
                .WithMessage(UiMessages.MAXIMUM_2000_SYMBOL_MESSAGE)
                .EmailAddress()
                .WithMessage(UiMessages.NOT_VALID_EMAIL);
        }
    }
}
