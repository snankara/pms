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

public class CreateEmployeeCommand:IRequest<CreatedEmployeeResponse>
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

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<CreatedEmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = _mapper.Map<Employee>(request);
            employee.Id = Guid.NewGuid();

            await _employeeRepository.AddAsync(employee);

            CreatedEmployeeResponse createdEmployeeResponse = _mapper.Map<CreatedEmployeeResponse>(employee);
            return createdEmployeeResponse;
        }
    }
}


