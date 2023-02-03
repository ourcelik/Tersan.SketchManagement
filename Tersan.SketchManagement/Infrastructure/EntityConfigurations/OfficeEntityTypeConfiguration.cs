using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tersan.SketchManagement.Infrastructure.Models;

namespace Tersan.SketchManagement.Infrastructure.EntityConfigurations
{
    public class OfficeEntityTypeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Offices");

            builder.HasKey("ID");

            builder.HasOne((office) => office.Building)
                .WithMany()
                .HasForeignKey("BuildingID")
                .OnDelete(DeleteBehavior.Cascade);

        

            builder.Property("Floor")
                .IsRequired();

            builder.Property("Name")
                .IsRequired()
                .HasMaxLength(100);
        }
    }
    
}
