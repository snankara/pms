using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Commands.Create;

public record CreatedEmployeeResponse(Guid Id, string FirstName, string LastName);