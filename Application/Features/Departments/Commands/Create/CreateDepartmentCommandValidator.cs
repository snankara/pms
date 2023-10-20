using FluentValidation;

namespace Application.Features.Departments.Commands.Create;

public sealed class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(3);
        RuleFor(c => c.Description).NotEmpty().MinimumLength(5);
    }
}
