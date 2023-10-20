using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Commands.Update;

public sealed class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(e => e.Id).NotEmpty();
        RuleFor(e => e.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(e => e.LastName).NotEmpty().MinimumLength(2);
        RuleFor(e => e.BirthDate).NotEmpty();
        RuleFor(e => e.TitleId).NotEmpty();
        RuleFor(e => e.DepartmentId).NotEmpty();
    }
}
