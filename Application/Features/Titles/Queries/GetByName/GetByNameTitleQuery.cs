using Application.Features.Titles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Titles.Queries.GetByName;

public sealed class GetByNameTitleQuery : IRequest<GetByNameTitleResponse>
{
    public string Name { get; set; }

    public class GetByNameTitleQueryHandler : IRequestHandler<GetByNameTitleQuery, GetByNameTitleResponse>
    {
        private readonly ITitleRepository _titleRepository;
        private readonly IMapper _mapper;
        private readonly TitleBusinessRules _titleBusinessRules;

        public GetByNameTitleQueryHandler(ITitleRepository titleRepository, IMapper mapper, TitleBusinessRules titleBusinessRules)
        {
            _titleRepository = titleRepository;
            _mapper = mapper;
            _titleBusinessRules = titleBusinessRules;
        }

        public async Task<GetByNameTitleResponse> Handle(GetByNameTitleQuery request, CancellationToken cancellationToken)
        {
            await _titleBusinessRules.TitleMustExistsWhenGetByName(request.Name);

            Title title = await _titleRepository.GetAsync(predicate: t => t.Name == request.Name, cancellationToken: cancellationToken);

            return _mapper.Map<GetByNameTitleResponse>(title);
        }
    }
}
