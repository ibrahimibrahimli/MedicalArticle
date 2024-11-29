using Business.BaseMessages;
using Entities.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class TeamBoardValidation : AbstractValidator<TeamBoard>
    {
        public TeamBoardValidation()
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

            RuleFor(x => x.Profession)
               .MinimumLength(3)
               .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
               .MaximumLength(100)
               .WithMessage(UiMessages.MAXIMUM_100_SYMBOL_MESSAGE)
               .NotEmpty()
               .WithMessage(UiMessages.NOT_EMPTY_MESSAGE);

            RuleFor(x => x.FacebookUrl)
               .MinimumLength(3)
               .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
               .MaximumLength(300)
               .WithMessage(UiMessages.MAXIMUM_300_SYMBOL_MESSAGE)
               .NotEmpty()
               .WithMessage(UiMessages.NOT_EMPTY_MESSAGE);

            RuleFor(x => x.LinkedinUrl)
             .MinimumLength(3)
             .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
             .MaximumLength(300)
             .WithMessage(UiMessages.MAXIMUM_300_SYMBOL_MESSAGE)
             .NotEmpty()
             .WithMessage(UiMessages.NOT_EMPTY_MESSAGE);

            RuleFor(x => x.InstagramUrl)
             .MinimumLength(3)
             .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE)
             .MaximumLength(300)
             .WithMessage(UiMessages.MAXIMUM_300_SYMBOL_MESSAGE)
             .NotEmpty()
             .WithMessage(UiMessages.NOT_EMPTY_MESSAGE);
        }
    }
}
