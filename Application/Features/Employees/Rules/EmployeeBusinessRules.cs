using Application.Features.Employees.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Employees.Rules;

public sealed class EmployeeBusinessRules : BaseBusinessRules
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ITitleRepository _titleRepository;
    private readonly IDepartmentRepository _departmentRepository;

    public EmployeeBusinessRules(IEmployeeRepository employeeRepository, ITitleRepository titleRepository, IDepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _titleRepository = titleRepository;
        _departmentRepository = departmentRepository;
    }

    public async Task TitleMustExistsWhenEmployeeInserted(Guid id)
    {
        bool result = await _titleRepository.AnyAsync(predicate: t => t.Id == id);

        if (!result) throw new BusinessException(EmployeesMessages.TitleInsertedToEmployeeWasNotFound);

    }

    public async Task DepartmentMustExistsWhenEmployeeInserted(Guid id)
    {
        bool result = await _departmentRepository.AnyAsync(predicate: t => t.Id == id);

        if (!result) throw new BusinessException(EmployeesMessages.DepartmentInsertedToEmployeeWasNotFound);

    }

    public async Task TitleMustExistsWhenEmployeeUpdated(Guid id)
    {
        bool result = await _titleRepository.AnyAsync(predicate: t => t.Id == id);

        if (!result) throw new BusinessException(EmployeesMessages.TitleInsertedToEmployeeWasNotFound);

    }

    public async Task DepartmentMustExistsWhenEmployeeUpdated(Guid id)
    {
        bool result = await _departmentRepository.AnyAsync(predicate: t => t.Id == id);

        if (!result) throw new BusinessException(EmployeesMessages.DepartmentInsertedToEmployeeWasNotFound);

    }

    public async Task EmployeeMustExistsWhenUpdated(Guid id)
    {
        bool result = await _employeeRepository.AnyAsync(predicate: t => t.Id == id);

        if (!result) throw new BusinessException(EmployeesMessages.NoEmployeetToUpdateWasFound);

    }

    public async Task EmployeeMustExistsWhenDeleted(Guid id)
    {
        bool result = await _employeeRepository.AnyAsync(predicate: t => t.Id == id);

        if (!result) throw new BusinessException(EmployeesMessages.NoEmployeeToDeleteWasFound);

    }
}
