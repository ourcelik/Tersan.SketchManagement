using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tersan.SketchManagement.Models;

namespace Tersan.SketchManagement.Infrastructure.EntityConfigurations
{
    public class ShipStatusEntityTypeConfiguration : IEntityTypeConfiguration<ShipStatus>
    {
        public void Configure(EntityTypeBuilder<ShipStatus> builder)
        {
            builder.ToTable("ShipStatuses");

            builder.HasKey("ID");

            builder.Property("StatusType")
                .IsRequired()
                .HasMaxLength(50);
        }
    }
    
}
