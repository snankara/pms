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

public class GetByIdTitleQuery : IRequest<GetByIdTitleResponse>
{
    public Guid Id { get; set; }

    public class GetByIdTitleQueryHandler : IRequestHandler<GetByIdTitleQuery, GetByIdTitleResponse>
    {
        private readonly ITitleRepository _titleRepository;
        private readonly IMapper _mapper;

        public GetByIdTitleQueryHandler(ITitleRepository titleRepository, IMapper mapper)
        {
            _titleRepository = titleRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdTitleResponse> Handle(GetByIdTitleQuery request, CancellationToken cancellationToken)
        {
            Title title = await _titleRepository.GetAsync(predicate: t => t.Id  == request.Id);

            return _mapper.Map<GetByIdTitleResponse>(title);
        }
    }
}
