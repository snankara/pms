using Core.Persistence.Repositories;
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
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public virtual Title? Title { get; set; }
    public virtual Department? Department { get; set; }

    public Employee(Guid titleId, Guid departmentId, string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        TitleId = titleId;
        DepartmentId = departmentId;
    }

    public Employee()
    {
    }

}
