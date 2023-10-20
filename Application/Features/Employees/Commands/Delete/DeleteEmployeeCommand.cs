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

namespace Application.Features.Employees.Commands.Delete;

public sealed class DeleteEmployeeCommand : IRequest<DeletedEmployeeResponse>
{
    public Guid Id { get; set; }

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, DeletedEmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly EmployeeBusinessRules _employeeBusinessRules;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper, EmployeeBusinessRules employeeBusinessRules)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _employeeBusinessRules = employeeBusinessRules;
        }

        public async Task<DeletedEmployeeResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _employeeBusinessRules.EmployeeMustExistsWhenDeleted(request.Id);

            Employee employeeToBeDeleted = await _employeeRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);

            await _employeeRepository.DeleteAsync(employeeToBeDeleted);

            DeletedEmployeeResponse response = _mapper.Map<DeletedEmployeeResponse>(employeeToBeDeleted);
            return response;
        }
    }
}
