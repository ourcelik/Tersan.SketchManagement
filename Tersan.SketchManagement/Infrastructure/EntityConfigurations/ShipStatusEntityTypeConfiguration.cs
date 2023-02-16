using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tersan.SketchManagement.Infrastructure.Models;

namespace Tersan.SketchManagement.Infrastructure.EntityConfigurations
{
    public class ShipStatusEntityTypeConfiguration : IEntityTypeConfiguration<ShipStatus>
    {
        const string CONST_MAINTENANCE_TR = "Bakımda";
        const string CONST_IN_PRODUCTION_TR = "Üretimde";

        public void Configure(EntityTypeBuilder<ShipStatus> builder)
        {
            builder.ToTable("ShipStatuses");

            builder.HasKey("ID");

            builder.Property("StatusType")
                .IsRequired()
                .HasMaxLength(50);

            //Seed data

            builder.HasData(
                new ShipStatus { ID = 1, StatusType = CONST_MAINTENANCE_TR },
                new ShipStatus { ID = 2, StatusType = CONST_IN_PRODUCTION_TR }
            );

        }
    }
    
}
