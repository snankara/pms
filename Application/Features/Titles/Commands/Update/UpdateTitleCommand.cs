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

namespace Application.Features.Titles.Commands.Update;

public sealed class UpdateTitleCommand : IRequest<UpdatedTitleResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateTitleCommandHandler : IRequestHandler<UpdateTitleCommand, UpdatedTitleResponse>
    {
        private readonly ITitleRepository _titleRepository;
        private readonly IMapper _mapper;
        private readonly TitleBusinessRules _titleBusinessRules;

        public UpdateTitleCommandHandler(ITitleRepository titleRepository, IMapper mapper, TitleBusinessRules titleBusinessRules)
        {
            _titleRepository = titleRepository;
            _mapper = mapper;
            _titleBusinessRules = titleBusinessRules;
        }

        public async Task<UpdatedTitleResponse> Handle(UpdateTitleCommand request, CancellationToken cancellationToken)
        {
            await _titleBusinessRules.TitleMustExistsWhenUpdated(request.Id);
            await _titleBusinessRules.TitleNameCannotBeDuplicatedWhenUpdated(request.Name);

            Title title = await _titleRepository.GetAsync(predicate: t => t.Id == request.Id);

            _mapper.Map(request, title);

            await _titleRepository.UpdateAsync(title);

            return _mapper.Map<UpdatedTitleResponse>(title);
        }
    }
}
