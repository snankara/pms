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

namespace Application.Features.Employees.Commands.Update;

public sealed class UpdateEmployeeCommand : IRequest<UpdatedEmployeeResponse>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid TitleId { get; set; }
    public Guid DepartmentId { get; set; }
    public DateTime BirthDate { get; set; }


    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, UpdatedEmployeeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeBusinessRules _employeeBusinessRules;

        public UpdateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository, EmployeeBusinessRules employeeBusinessRules)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _employeeBusinessRules = employeeBusinessRules;
        }

        public async Task<UpdatedEmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _employeeBusinessRules.EmployeeMustExistsWhenUpdated(request.Id);
            await _employeeBusinessRules.TitleMustExistsWhenEmployeeUpdated(request.TitleId);
            await _employeeBusinessRules.DepartmentMustExistsWhenEmployeeUpdated(request.DepartmentId);

            Employee employeeToBeUpdate = await _employeeRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);

            _mapper.Map(request, employeeToBeUpdate);

            await _employeeRepository.UpdateAsync(employeeToBeUpdate);
        
            return _mapper.Map<UpdatedEmployeeResponse>(employeeToBeUpdate);
        }
    }
}
