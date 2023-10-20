using Application.Features.Titles.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Titles.Rules;

public sealed class TitleBusinessRules : BaseBusinessRules
{
    private readonly ITitleRepository _titleRepository;

    public TitleBusinessRules(ITitleRepository titleRepository)
    {
        _titleRepository = titleRepository;
    }

    public async Task TitleNameCannotBeDuplicatedWhenInserted(string name)
    {
        bool result = await _titleRepository.AnyAsync(predicate: t => t.Name.ToLower() == name.ToLower());

        if (result) throw new BusinessException(TitlesMessages.TitleNameExists);
        
    }

    public async Task TitleMustExistsWhenUpdated(Guid id)
    {
        bool result = await _titleRepository.AnyAsync(predicate: t => t.Id == id);

        if (!result) throw new BusinessException(TitlesMessages.NoTitleToUpdateWasFound);

    }

    public async Task TitleMustExistsWhenDeleted(Guid id)
    {
        bool result = await _titleRepository.AnyAsync(predicate: t => t.Id == id);

        if (!result) throw new BusinessException(TitlesMessages.NoTitleToDeleteWasFound);

    }

    public async Task TitleMustExistsWhenGetByName(string name)
    {
        bool result = await _titleRepository.AnyAsync(predicate: t => t.Name.ToLower() == name.ToLower());

        if (!result) throw new BusinessException(TitlesMessages.NoTitleToRetrieveWasFound);

    }

    public async Task TitleMustExistsWhenGetById(Guid id)
    {
        bool result = await _titleRepository.AnyAsync(predicate: t => t.Id == id);

        if (!result) throw new BusinessException(TitlesMessages.NoTitleToRetrieveWasFound);

    }
}
