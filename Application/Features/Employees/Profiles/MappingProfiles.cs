using Application.Features.Employees.Commands.Create;
using Application.Features.Employees.Commands.Delete;
using Application.Features.Employees.Commands.Update;
using Application.Features.Employees.Queries.GetById;
using Application.Features.Employees.Queries.GetList;
using Application.Features.Employees.Queries.GetListByDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Employees.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
        CreateMap<Employee, CreatedEmployeeResponse>().ReverseMap();

        CreateMap<Paginate<Employee>, GetListResponse<GetListEmployeeListItemDto>>().ReverseMap();
        CreateMap<Employee, GetListEmployeeListItemDto>()
            .ForMember(destinationMember: e => e.DepartmentName, memberOptions: opt => opt.MapFrom(e => e.Department.Name))
            .ReverseMap();

        CreateMap<Employee, GetByIdEmployeeResponse>().ReverseMap();

        CreateMap<Employee, UpdatedEmployeeResponse>().ReverseMap();
        CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();

        CreateMap<Employee, DeletedEmployeeResponse>().ReverseMap();

        CreateMap<Paginate<Employee>, GetListResponse<GetListByDynamicEmployeeListItemDto>>().ReverseMap();
        CreateMap<Employee, GetListByDynamicEmployeeListItemDto>().ReverseMap();


    }
}
