using FluentValidation;

namespace Application.Features.Departments.Commands.Create;

public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(3);
        RuleFor(c => c.Description).NotEmpty().MinimumLength(5);
    }
}
