using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DepartmentRepository : EfRepositoryBase<Department, Guid, BaseDbContext>, IDepartmentRepository
{
    public DepartmentRepository(BaseDbContext context) : base(context)
    {
    }
}
