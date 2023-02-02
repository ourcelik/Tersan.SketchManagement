using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tersan.SketchManagement.Models;

namespace Tersan.SketchManagement.Infrastructure.EntityConfigurations
{
    public class ShipEntityTypeConfiguration : IEntityTypeConfiguration<Ship>
    {
        public void Configure(EntityTypeBuilder<Ship> builder)
        {
            builder.ToTable("Ships");

            builder.HasKey("ID");

            builder.HasOne((ship) => ship.Sketch)
                .WithMany()
                .HasForeignKey("SketchID")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne((ship) => ship.ShipStatus)
                .WithMany()
                .HasForeignKey("ShipStatusID")
                .OnDelete(DeleteBehavior.Cascade);
            
        }
        
    }
    
}
