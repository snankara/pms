using Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EmployeeService;

public sealed class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeManager(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<int> GetActiveTotalCount()
    {
        return await _employeeRepository.GetCountAsync();
    }
}
