using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Commands.Create;

public sealed class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(e => e.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(e => e.LastName).NotEmpty().MinimumLength(2);
        RuleFor(e => e.BirthDate).NotEmpty();
        RuleFor(e => e.TitleId).NotEmpty();
        RuleFor(e => e.DepartmentId).NotEmpty();
    }
}
