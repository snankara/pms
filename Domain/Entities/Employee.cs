using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Employee : Entity<Guid>
{
    public Guid TitleId { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid UserId { get; set; }
    public DateTime BirthDate { get; set; }

    public virtual Title? Title { get; set; }
    public virtual Department? Department { get; set; }
    public virtual User User { get; set; }

    public Employee(Guid titleId, Guid departmentId, DateTime birthDate)
    {
        BirthDate = birthDate;
        TitleId = titleId;
        DepartmentId = departmentId;
    }

    public Employee()
    {
    }

}
