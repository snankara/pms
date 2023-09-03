using Application.Features.Titles.Commands.Create;
using Application.Features.Titles.Commands.Delete;
using Application.Features.Titles.Commands.Update;
using Application.Features.Titles.Queries.GetById;
using Application.Features.Titles.Queries.GetByName;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Titles.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Title, CreateTitleCommand>().ReverseMap();
        CreateMap<Title, CreatedTitleResponse>().ReverseMap();

        CreateMap<Title, DeletedTitleResponse>().ReverseMap();

        CreateMap<Title, UpdateTitleCommand>().ReverseMap();
        CreateMap<Title, UpdatedTitleResponse>().ReverseMap();

        CreateMap<Title, GetByIdTitleResponse>().ReverseMap(); 

        CreateMap<Title, GetByNameTitleResponse>().ReverseMap();
    }
}
