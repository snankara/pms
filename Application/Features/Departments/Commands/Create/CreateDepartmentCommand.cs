using Application.Features.Departments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Commands.Create;

public sealed class CreateDepartmentCommand : IRequest<CreatedDepartmentResponse>, ITransactionalRequest,  ICacheRemoverRequest, ILoggableRequest
{
    public string Name { get; set; }
    public string Description { get; set; }

    public string? CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetDepartments";

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, CreatedDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly DepartmentBusinessRules _departmentBusinessRules;

        public CreateDepartmentCommandHandler(IMapper mapper, IDepartmentRepository departmentRepository, DepartmentBusinessRules departmentBusinessRules)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
            _departmentBusinessRules = departmentBusinessRules;
        }

        public async Task<CreatedDepartmentResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            await _departmentBusinessRules.DepartmentNameCannotBeDuplicatedWhenInserted(request.Name);

            Department department = _mapper.Map<Department>(request);

            await _departmentRepository.AddAsync(department);

            return _mapper.Map<CreatedDepartmentResponse>(department);
        }
    }
}
