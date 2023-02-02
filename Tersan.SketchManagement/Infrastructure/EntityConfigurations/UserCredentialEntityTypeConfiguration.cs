using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tersan.SketchManagement.Models;

namespace Tersan.SketchManagement.Infrastructure.EntityConfigurations
{
    public class UserCredentialEntityTypeConfiguration : IEntityTypeConfiguration<UserCredential>
    {
        public void Configure(EntityTypeBuilder<UserCredential> builder)
        {
            builder.ToTable("UserCredentials");

            builder.HasKey("ID");

            builder.HasOne((userCredential) => userCredential.Employee)
                .WithMany()
                .HasForeignKey("EmployeeID")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne((userCredential) => userCredential.Credential)
                .WithMany()
                .HasForeignKey("CredentialID")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
