using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Titles.Commands.Delete;

public sealed class DeleteTitleCommandValidator : AbstractValidator<DeleteTitleCommand>
{
    public DeleteTitleCommandValidator()
    {
        RuleFor(t => t.Id).NotEmpty();
    }
}
