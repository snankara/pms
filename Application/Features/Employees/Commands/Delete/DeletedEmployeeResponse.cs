using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Commands.Delete;

public record DeletedEmployeeResponse(Guid Id, string FirstName);
