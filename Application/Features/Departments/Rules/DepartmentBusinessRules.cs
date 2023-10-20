using Application.Features.Departments.Constants;
using Application.Features.Titles.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Rules;

public sealed class DepartmentBusinessRules : BaseBusinessRules
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentBusinessRules(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task DepartmentNameCannotBeDuplicatedWhenInserted(string name)
    {
        bool result = await _departmentRepository.AnyAsync(predicate: t => t.Name.ToLower() == name.ToLower());

        if (result) throw new BusinessException(DepartmentsMessages.DepartmentNameExists);

    }

    public async Task DepartmentMustExistsWhenUpdated(Guid id)
    {
        bool result = await _departmentRepository.AnyAsync(predicate: t => t.Id == id);

        if (!result) throw new BusinessException(DepartmentsMessages.NoDepartmentToUpdateWasFound);

    }

    public async Task DepartmentMustExistsWhenDeleted(Guid id)
    {
        bool result = await _departmentRepository.AnyAsync(predicate: t => t.Id == id);

        if (!result) throw new BusinessException(DepartmentsMessages.NoDepartmentToDeleteWasFound);

    }
}
