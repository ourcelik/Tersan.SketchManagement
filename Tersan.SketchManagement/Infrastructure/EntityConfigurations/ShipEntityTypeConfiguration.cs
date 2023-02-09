using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tersan.SketchManagement.Infrastructure.Models;

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

            builder.Property((ship) => ship.WindowWidth)
                .HasColumnType("decimal(18,6)")
                .IsRequired();

            builder.Property((ship) => ship.WindowHeight)
                .HasColumnType("decimal(18,6)")
                .IsRequired();


        }
        
    }
    
}
