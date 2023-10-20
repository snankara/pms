using Application.Features.Employees.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Commands.Create;

public sealed class CreateEmployeeCommand:IRequest<CreatedEmployeeResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid TitleId { get; set; }
    public Guid DepartmentId { get; set; }
    public DateTime BirthDate { get; set; }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreatedEmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly EmployeeBusinessRules _employeeBusinessRules;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper, EmployeeBusinessRules employeeBusinessRules)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _employeeBusinessRules = employeeBusinessRules;
        }

        public async Task<CreatedEmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _employeeBusinessRules.TitleMustExistsWhenEmployeeInserted(request.TitleId);
            await _employeeBusinessRules.DepartmentMustExistsWhenEmployeeInserted(request.DepartmentId);

            Employee employee = _mapper.Map<Employee>(request);

            await _employeeRepository.AddAsync(employee);

            CreatedEmployeeResponse createdEmployeeResponse = _mapper.Map<CreatedEmployeeResponse>(employee);
            return createdEmployeeResponse;
        }
    }
}


