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

namespace Application.Features.Departments.Commands.Update;

public class UpdateDepartmentCommand : IRequest<UpdatedDepartmentResponse>, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string? CacheKey => "";
    public bool BypassCache => false;

    public string? CacheGroupKey => "GetDepartments";

    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, UpdatedDepartmentResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedDepartmentResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department department = await _departmentRepository.GetAsync(d => d.Id == request.Id);

            _mapper.Map<Department>(request);

            await _departmentRepository.UpdateAsync(department);

            return _mapper.Map<UpdatedDepartmentResponse>(request);
        }
    }
}
