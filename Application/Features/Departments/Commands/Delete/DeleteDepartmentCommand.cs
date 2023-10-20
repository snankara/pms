using Application.Features.Departments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Commands.Delete;

public sealed class DeleteDepartmentCommand : IRequest<DeletedDepartmentResponse>, ICacheRemoverRequest
{
    public Guid Id { get; set; }

    public string? CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetDepartments";


    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, DeletedDepartmentResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly DepartmentBusinessRules _departmentBusinessRules;

        public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper, DepartmentBusinessRules departmentBusinessRules)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _departmentBusinessRules = departmentBusinessRules;
        }

        public async Task<DeletedDepartmentResponse> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            await _departmentBusinessRules.DepartmentMustExistsWhenDeleted(request.Id);

            Department department = await _departmentRepository.GetAsync(d => d.Id  == request.Id);

            await _departmentRepository.DeleteAsync(department);

            return _mapper.Map<DeletedDepartmentResponse>(department);
        }
    }
}
