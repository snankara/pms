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

public class DeleteDepartmentCommand : IRequest<DeletedDepartmentResponse>, ICacheRemoverRequest
{
    public Guid Id { get; set; }

    public string? CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetDepartments";


    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, DeletedDepartmentResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<DeletedDepartmentResponse> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department department = await _departmentRepository.GetAsync(d => d.Id  == request.Id);

            await _departmentRepository.DeleteAsync(department);

            return _mapper.Map<DeletedDepartmentResponse>(department);
        }
    }
}
