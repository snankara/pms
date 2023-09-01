using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Title : Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<Employee> Employees { get; set; }

    public Title(string name): this()
    {
        Name = name;
    }

    public Title()
    {
        Employees = new HashSet<Employee>();
    }
}
