using Application.Features.Departments.Commands.Create;
using Application.Features.Departments.Commands.Delete;
using Application.Features.Departments.Commands.Update;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Department, CreateDepartmentCommand>().ReverseMap();
        CreateMap<Department, CreatedDepartmentResponse>().ReverseMap();

        CreateMap<Department, DeletedDepartmentResponse>().ReverseMap();

        CreateMap<Department, UpdatedDepartmentResponse>().ReverseMap();
        CreateMap<Department, UpdateDepartmentCommand>().ReverseMap();
    }
}
