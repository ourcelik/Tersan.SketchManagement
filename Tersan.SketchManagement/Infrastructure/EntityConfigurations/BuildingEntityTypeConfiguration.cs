using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tersan.SketchManagement.Infrastructure.Models;

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

            builder.Property("X")
                .IsRequired();

            //change X sensitivity
            builder.Property("X")
                .HasPrecision(18, 6);

            builder.Property("Y")
                .IsRequired();

            //change Y sensitivity

            builder.Property("Y")
                .HasPrecision(18, 6);

        }
    }
    
}
