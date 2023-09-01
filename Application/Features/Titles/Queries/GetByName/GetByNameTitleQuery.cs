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

public class GetByNameTitleQuery : IRequest<GetByNameTitleResponse>
{
    public string Name { get; set; }

    public class GetByNameTitleQueryHandler : IRequestHandler<GetByNameTitleQuery, GetByNameTitleResponse>
    {
        private readonly ITitleRepository _titleRepository;
        private readonly IMapper _mapper;

        public GetByNameTitleQueryHandler(ITitleRepository titleRepository, IMapper mapper)
        {
            _titleRepository = titleRepository;
            _mapper = mapper;
        }

        public async Task<GetByNameTitleResponse> Handle(GetByNameTitleQuery request, CancellationToken cancellationToken)
        {
            Title title = await _titleRepository.GetAsync(predicate: t => t.Name == request.Name);

            return _mapper.Map<GetByNameTitleResponse>(title);
        }
    }
}
