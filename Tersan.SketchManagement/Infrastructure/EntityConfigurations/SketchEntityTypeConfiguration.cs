using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tersan.SketchManagement.Infrastructure.Models;

namespace Tersan.SketchManagement.Infrastructure.EntityConfigurations
{
    public class SketchEntityTypeConfiguration : IEntityTypeConfiguration<Sketch>
    {
        public void Configure(EntityTypeBuilder<Sketch> builder)
        {
            builder.ToTable("Sketches");

            builder.HasKey("ID");

            builder.Property("ImageUrl")
                .IsRequired()
                .HasMaxLength(200);
            
            builder.Property("Name")
                .IsRequired()
                .HasMaxLength(100);
                
            builder.HasIndex("Name")
                .IsUnique();

            builder.Property("Description")
                .IsRequired()
                .HasMaxLength(500);
            
        }
    }
    
}
