using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tersan.SketchManagement.Models;

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
                .IsRequired();

            builder.Property("Surname")
                .IsRequired();

            builder.Property("Email")
                .IsRequired();

            builder.Property("Password")
                .IsRequired();

            builder.Property("Phone");

            builder.Property("Address");
        }
    }
    
}
