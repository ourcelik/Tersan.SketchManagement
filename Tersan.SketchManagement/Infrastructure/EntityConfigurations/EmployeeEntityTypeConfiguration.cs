using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tersan.SketchManagement.Infrastructure.Models;

namespace Tersan.SketchManagement.Infrastructure.EntityConfigurations
{
    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey("ID");

            builder.HasOne((employee) => employee.Office)
                .WithMany()
                .HasForeignKey("OfficeID")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property("Name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property("Surname")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property("Email")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property("PasswordHash")
                .IsRequired()
                .HasMaxLength(500);
            builder.Property("PasswordSalt")
                .IsRequired()
                .HasMaxLength(500);

            builder.Property("Phone")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property("Address")
                .HasMaxLength(500);


        }
    }
    
}
