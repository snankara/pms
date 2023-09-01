using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Commands.Delete;

public class DeletedEmployeeResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
}
