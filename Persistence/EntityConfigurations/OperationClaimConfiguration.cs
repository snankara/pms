using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

        //builder.HasData(_seeds);

    }

    /*private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            //Guid id = 0;

            yield return new OperationClaim(Guid.NewGuid(), GeneralOperationClaims.Admin);

            IEnumerable<Type> featureOperationClaimsTypes = Assembly
                .GetAssembly(typeof(ApplicationServiceRegistration))!
                .GetTypes()
                .Where(
                type => 
                    (type.Namespace?.Contains("Feature") == true)
                    && (type.Namespace?.Contains("Constans") == true)
                    && type.IsClass 
                    && type.Name.EndsWith("OperationClaims")
                );

            foreach (Type type in featureOperationClaimsTypes)
            {
                FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);

                IEnumerable<string> values = fields.Select(field => field.GetValue(null)!.ToString()!);

                IEnumerable<OperationClaim> featureOperationsClaimsToAdd = values.Select(
                    value => new OperationClaim(id: Guid.NewGuid(), name: value)
                    );

                foreach (OperationClaim featureOperationClaim in featureOperationsClaimsToAdd)
                {
                    yield return featureOperationClaim;
                }
            }
        }
    }*/
}
