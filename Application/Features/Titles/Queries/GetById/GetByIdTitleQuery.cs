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

namespace Application.Features.Titles.Queries.GetById;

public sealed class GetByIdTitleQuery : IRequest<GetByIdTitleResponse>
{
    public Guid Id { get; set; }

    public class GetByIdTitleQueryHandler : IRequestHandler<GetByIdTitleQuery, GetByIdTitleResponse>
    {
        private readonly ITitleRepository _titleRepository;
        private readonly IMapper _mapper;
        private readonly TitleBusinessRules _titleBusinessRules;

        public GetByIdTitleQueryHandler(ITitleRepository titleRepository, IMapper mapper, TitleBusinessRules titleBusinessRules)
        {
            _titleRepository = titleRepository;
            _mapper = mapper;
            _titleBusinessRules = titleBusinessRules;
        }

        public async Task<GetByIdTitleResponse> Handle(GetByIdTitleQuery request, CancellationToken cancellationToken)
        {
            await _titleBusinessRules.TitleMustExistsWhenGetById(request.Id);

            Title title = await _titleRepository.GetAsync(predicate: t => t.Id  == request.Id, cancellationToken: cancellationToken);

            return _mapper.Map<GetByIdTitleResponse>(title);
        }
    }
}
