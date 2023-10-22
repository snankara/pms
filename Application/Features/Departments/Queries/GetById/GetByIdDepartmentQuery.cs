using Application.Features.Departments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Queries.GetById;

public sealed class GetByIdDepartmentQuery : IRequest<GetByIdDepartmentResponse>, ILoggableRequest, ICachableRequest
{
    public Guid Id { get; set; }

    public string CacheKey => $"GetByIdDepartmentQuery({Id})";

    public bool BypassCache { get; }

    public string? CacheGroupKey => "GetDepartments";

    public TimeSpan? SlidingExpiration { get; }

    public class GetByIdDepartmentQueryHandler : IRequestHandler<GetByIdDepartmentQuery, GetByIdDepartmentResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly DepartmentBusinessRules _departmentBusinessRules;
        private readonly IMapper _mapper;

        public GetByIdDepartmentQueryHandler(IDepartmentRepository departmentRepository, DepartmentBusinessRules departmentBusinessRules, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _departmentBusinessRules = departmentBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetByIdDepartmentResponse> Handle(GetByIdDepartmentQuery request, CancellationToken cancellationToken)
        {
            await _departmentBusinessRules.DepartmentMustExistsWhenGetById(request.Id);

            Department department = await _departmentRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
        
            return _mapper.Map<GetByIdDepartmentResponse>(department);
        }
    }
}
