using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Department : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Employee> Employees { get; set; }


    public Department(string name, string description): this()
    {
        Name = name;
        Description = description;
    }

    public Department()
    {
        //Employees = new HashSet<Employee>();
    }
}
