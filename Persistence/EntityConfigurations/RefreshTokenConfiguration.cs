using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens").HasKey(t => t.Id);

        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(t => t.Token).HasColumnName("Token").IsRequired();
        builder.Property(t => t.Expires).HasColumnName("Expires").IsRequired();
        builder.Property(t => t.CreatedByIp).HasColumnName("CreatedByIp").IsRequired();
        builder.Property(t => t.Revoked).HasColumnName("Revoked");
        builder.Property(t => t.RevokedByIp).HasColumnName("RevokedByIp");
        builder.Property(t => t.ReplacedByToken).HasColumnName("ReplacedByToken");
        builder.Property(t => t.ReasonRevoked).HasColumnName("ReasonRevoked");
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);

        builder.HasOne(t => t.User);
    }
}
