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
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE)
                .MaximumLength(300)
                .WithMessage(UiMessages.MAXIMUM_300_SYMBOL_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE);

            RuleFor(c => c.IconName)
                .NotEmpty()
                .WithMessage(UiMessages.NOT_EMPTY_MESSAGE)
                .MaximumLength(100)
                .WithMessage(UiMessages.MAXIMUM_100_SYMBOL_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UiMessages.MINIMUM_3_SYMBOL_MESSAGE);
        }
    }
}
