using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Commands.Create;

public class CreatedDepartmentResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
