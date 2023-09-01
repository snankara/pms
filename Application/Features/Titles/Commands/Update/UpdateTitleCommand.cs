using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Titles.Commands.Update;

public class UpdateTitleCommand : IRequest<UpdatedTitleResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateTitleCommandHandler : IRequestHandler<UpdateTitleCommand, UpdatedTitleResponse>
    {
        private readonly ITitleRepository _titleRepository;
        private readonly IMapper _mapper;

        public UpdateTitleCommandHandler(ITitleRepository titleRepository, IMapper mapper)
        {
            _titleRepository = titleRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedTitleResponse> Handle(UpdateTitleCommand request, CancellationToken cancellationToken)
        {
            Title title = await _titleRepository.GetAsync(predicate: t => t.Id == request.Id);

            _mapper.Map(request, title);

            await _titleRepository.UpdateAsync(title);

            return _mapper.Map<UpdatedTitleResponse>(title);
        }
    }
}
