using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Queries.GetById;

public record GetByIdDepartmentResponse(Guid Id, string Name, string Description);
