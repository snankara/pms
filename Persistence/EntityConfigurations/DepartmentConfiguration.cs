using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.Name).HasColumnName("Name").IsRequired();
        builder.Property(e => e.Description).HasColumnName("Description").IsRequired();
        builder.Property(e => e.CreatedDate).HasColumnName("CreateDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: d=>d.Name, name:"UK_Departments_Name").IsUnique();
        builder.HasMany(d => d.Employees);

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}
