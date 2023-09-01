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

public class UpdateEmployeeCommand : IRequest<UpdatedEmployeeResponse>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, UpdatedEmployeeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<UpdatedEmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employeeToBeUpdate = await _employeeRepository.GetAsync(predicate: e => e.Id == request.Id);

            employeeToBeUpdate = _mapper.Map(request, employeeToBeUpdate);

            await _employeeRepository.UpdateAsync(employeeToBeUpdate);

            var response = _mapper.Map<UpdatedEmployeeResponse>(employeeToBeUpdate);
        
            return response;
        }
    }
}
