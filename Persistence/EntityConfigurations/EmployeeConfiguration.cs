using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.DepartmentId).HasColumnName("DepartmentId").IsRequired();
        builder.Property(e => e.TitleId).HasColumnName("TitleId").IsRequired();
        builder.Property(e => e.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(e => e.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(e => e.BirthDate).HasColumnName("BirthDate").IsRequired();
        builder.Property(e => e.CreatedDate).HasColumnName("CreateDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(e => e.Department);
        builder.HasOne(e => e.Title);


        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}
