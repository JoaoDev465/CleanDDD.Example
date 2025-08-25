using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD_clean_architecture.Infrastructure;

public class ContextConfigurations: IEntityTypeConfiguration<CarStorage>
{
    public void Configure(EntityTypeBuilder<CarStorage> builder)
    {
        builder.Property(x => x.Id).UseIdentityColumn()
            .ValueGeneratedOnAdd();
        builder.Property(x => x.Carcolor).IsRequired()
            .HasColumnType("Nvarchar").HasMaxLength(50);
        builder.Property(x => x.CarPrice).IsRequired()
            .HasColumnType("Decimal(18,2)");
        builder.Property(x => x.IsSold)
            .HasColumnType("BIT");
    }
}