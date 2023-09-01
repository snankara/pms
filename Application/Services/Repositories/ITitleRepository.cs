using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ITitleRepository : IAsyncRepository<Title, Guid>
{
}
