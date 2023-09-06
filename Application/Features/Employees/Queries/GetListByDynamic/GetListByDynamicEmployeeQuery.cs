using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Employees.Queries.GetListByDynamic;

public class GetListByDynamicEmployeeQuery : IRequest<GetListResponse<GetListByDynamicEmployeeListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public class GetListByDynamicEmployeeQueryHandler : IRequestHandler<GetListByDynamicEmployeeQuery, GetListResponse<GetListByDynamicEmployeeListItemDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetListByDynamicEmployeeQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByDynamicEmployeeListItemDto>> Handle(GetListByDynamicEmployeeQuery request, CancellationToken cancellationToken)
        {
            Paginate<Employee> employees = await _employeeRepository.GetListByDynamicAsync(
                dynamic: request.DynamicQuery,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: e => e.Include(e => e.Department).Include(e => e.Title),
                cancellationToken: cancellationToken
                );

            return _mapper.Map<GetListResponse<GetListByDynamicEmployeeListItemDto>>(employees);
        }
    }
}
