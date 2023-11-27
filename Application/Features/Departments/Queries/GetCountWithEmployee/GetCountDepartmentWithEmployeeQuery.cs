using Application.Services.EmployeeService;
using Application.Services.Repositories;
using Core.Application.Pipelines.Logging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Queries.GetCountWithEmployee;

public sealed class GetCountDepartmentWithEmployeeQuery : IRequest<GetCountDepartmentWithEmployeeResponse>, ILoggableRequest
{
    public class GetCountDepartmentWithEmployeeQueryHandler : IRequestHandler<GetCountDepartmentWithEmployeeQuery, GetCountDepartmentWithEmployeeResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeService _employeeService;

        public GetCountDepartmentWithEmployeeQueryHandler(IDepartmentRepository departmentRepository, IEmployeeService employeeService)
        {
            _departmentRepository = departmentRepository;
            _employeeService = employeeService;
        }

        public async Task<GetCountDepartmentWithEmployeeResponse> Handle(GetCountDepartmentWithEmployeeQuery request, CancellationToken cancellationToken)
        {
            int activeCount = await _departmentRepository.GetCountAsync(cancellationToken: cancellationToken);

            int deletedCount = await _departmentRepository.GetCountAsync(
                withDeleted: true, 
                predicate: d => d.DeletedDate.HasValue, 
                cancellationToken: cancellationToken
                );

            int totalEmployeeCount = await _employeeService.GetActiveTotalCount();

            GetCountDepartmentWithEmployeeResponse response = new
                (
                    activeCount, 
                    deletedCount, 
                    TotalCount: activeCount + deletedCount,
                    TotalEmployeeCount: totalEmployeeCount
                );             

            return response;
        }
    }
}
