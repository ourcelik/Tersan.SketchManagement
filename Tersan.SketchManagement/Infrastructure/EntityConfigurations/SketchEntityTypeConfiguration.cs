using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tersan.SketchManagement.Models;

namespace Tersan.SketchManagement.Infrastructure.EntityConfigurations
{
    public class SketchEntityTypeConfiguration : IEntityTypeConfiguration<Sketch>
    {
        public void Configure(EntityTypeBuilder<Sketch> builder)
        {
            builder.ToTable("Sketches");

            builder.HasKey("ID");

            builder.Property("ImageUrl")
                .IsRequired();
        }
    }
    
}
