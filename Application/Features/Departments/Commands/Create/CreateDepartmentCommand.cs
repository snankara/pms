using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Commands.Create;

public class CreateDepartmentCommand : IRequest<CreatedDepartmentResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, CreatedDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public CreateDepartmentCommandHandler(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<CreatedDepartmentResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department department = _mapper.Map<Department>(request);

            await _departmentRepository.AddAsync(department);

            return _mapper.Map<CreatedDepartmentResponse>(department);
        }
    }
}
