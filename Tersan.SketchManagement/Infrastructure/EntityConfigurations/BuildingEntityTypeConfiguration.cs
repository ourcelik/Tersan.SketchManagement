using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tersan.SketchManagement.Models;

namespace Tersan.SketchManagement.Infrastructure.EntityConfigurations
{
    public class BuildingEntityTypeConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.ToTable("Buildings");

            builder.HasKey("ID");

            builder.HasOne((building) => building.Sketch)
                .WithMany()
                .HasForeignKey("SketchID")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne((building) => building.Point)
                .WithMany()
                .HasForeignKey("PointID")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
