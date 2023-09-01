using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TitleRepository : EfRepositoryBase<Title, Guid, BaseDbContext>, ITitleRepository
{
    public TitleRepository(BaseDbContext context) : base(context)
    {
    }
}
