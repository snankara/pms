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

namespace Application.Features.Titles.Commands.Create;

public class CreateTitleCommand : IRequest<CreatedTitleResponse>
{
    public string Name { get; set; }

    public class CreateTitleCommandHandler : IRequestHandler<CreateTitleCommand, CreatedTitleResponse>
    {
        private readonly ITitleRepository _titleRepository;
        private readonly TitleBusinessRules _titleBusinessRules;
        private readonly IMapper _mapper;

        public CreateTitleCommandHandler(ITitleRepository titleRepository, TitleBusinessRules titleBusinessRules, IMapper mapper)
        {
            _titleRepository = titleRepository;
            _titleBusinessRules = titleBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreatedTitleResponse> Handle(CreateTitleCommand request, CancellationToken cancellationToken)
        {
            await _titleBusinessRules.TitleNameCannotBeDuplicatedWhenInserted(request.Name);

            Title title = _mapper.Map<Title>(request);
            title.Id = Guid.NewGuid();

            await _titleRepository.AddAsync(title);

            return _mapper.Map<CreatedTitleResponse>(title);

        }
    }
}
