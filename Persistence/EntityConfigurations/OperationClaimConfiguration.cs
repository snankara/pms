using Application;
using Core.Security.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(t => t.Id);

        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.Name).HasColumnName("Name").IsRequired();
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);

        builder.HasMany(t => t.UserOperationClaims);

        builder.HasData(_seeds);

    }

    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            int id = 0;

            yield return new OperationClaim { Id = ++id, Name = GeneralOperationClaim.Admin, CreatedDate = DateTime.Now };

            #region Feature Operation Claims
            IEnumerable<Type> featureOperationClaimsTypes = Assembly
                .GetAssembly(typeof(ApplicationServiceRegistration))!
                .GetTypes()
                .Where(
                    type =>
                        (type.Namespace?.Contains("Features") == true)
                        && (type.Namespace?.Contains("Constants") == true)
                        && type.IsClass
                        && type.Name.EndsWith("OperationClaims")
                );
            foreach (Type type in featureOperationClaimsTypes)
            {
                FieldInfo[] typeFields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
                IEnumerable<string> typeFieldsValues = typeFields.Select(field => field.GetValue(null)!.ToString()!);

                IEnumerable<OperationClaim> featureOperationClaimsToAdd = typeFieldsValues.Select(
                    value => new OperationClaim { Id = ++id, Name = value, CreatedDate = DateTime.Now }
                );
                foreach (OperationClaim featureOperationClaim in featureOperationClaimsToAdd)
                    yield return featureOperationClaim;
            }
            #endregion
        }
    }
}
