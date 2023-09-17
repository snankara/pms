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

public class TitleBusinessRules : BaseBusinessRules
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
}
