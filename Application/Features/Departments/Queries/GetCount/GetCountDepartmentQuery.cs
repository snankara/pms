using Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Queries.GetCount;

public sealed class GetCountDepartmentQuery : IRequest<GetCountDepartmentResponse>
{
    public class GetCountDepartmentQueryHandler : IRequestHandler<GetCountDepartmentQuery, GetCountDepartmentResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetCountDepartmentQueryHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<GetCountDepartmentResponse> Handle(GetCountDepartmentQuery request, CancellationToken cancellationToken)
        {
            int activeCount = await _departmentRepository.GetCount(cancellationToken: cancellationToken);

            int deletedCount = await _departmentRepository.GetCount(withDeleted: true, predicate: d => d.DeletedDate.HasValue, cancellationToken: cancellationToken);

            GetCountDepartmentResponse response = new
                (
                    activeCount, 
                    deletedCount, 
                    TotalCount: activeCount + deletedCount
                );             

            return response;
        }
    }
}
