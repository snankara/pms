using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Titles.Commands.Create;

public class CreateTitleCommandValidator : AbstractValidator<CreateTitleCommand>
{
    public CreateTitleCommandValidator()
    {
        RuleFor(t => t.Name).NotEmpty().MinimumLength(5);
    }
}
