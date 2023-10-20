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

namespace Application.Features.Titles.Commands.Delete;

public sealed class DeleteTitleCommand : IRequest<DeletedTitleResponse>
{
    public Guid Id { get; set; }

    public class DeleteTitleCommandHandler : IRequestHandler<DeleteTitleCommand, DeletedTitleResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleRepository _titleRepository;
        private readonly TitleBusinessRules _titleBusinessRules;

        public DeleteTitleCommandHandler(IMapper mapper, ITitleRepository titleRepository, TitleBusinessRules titleBusinessRules)
        {
            _mapper = mapper;
            _titleRepository = titleRepository;
            _titleBusinessRules = titleBusinessRules;
        }

        public async Task<DeletedTitleResponse> Handle(DeleteTitleCommand request, CancellationToken cancellationToken)
        {
            await _titleBusinessRules.TitleMustExistsWhenDeleted(request.Id);

            Title title = await _titleRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);

            await _titleRepository.DeleteAsync(title);

            return _mapper.Map<DeletedTitleResponse>(title);
        }
    }
}
