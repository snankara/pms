using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Commands.Update;

public record UpdatedDepartmentResponse(Guid Id, string Name);

