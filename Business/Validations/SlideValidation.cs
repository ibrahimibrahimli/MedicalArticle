﻿using Business.BaseMessages;
using Entities.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class SlideValidation : AbstractValidator<Slide>
    {
        public SlideValidation()
        {
            RuleFor(x => x.Content)
               .MinimumLength(100)
               .WithMessage(UiMessages.MINIMUM_100_SYMBOL_MESSAGE)
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