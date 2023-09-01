using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Commands.Update;

public class UpdatedEmployeeResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
}
