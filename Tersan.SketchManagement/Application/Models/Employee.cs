using Tersan.SketchManagement.Infrastructure.Models.Base;

namespace Tersan.SketchManagement.Infrastructure.Models
{
    public class Employee : BaseModel
    {
        public int OfficeID { get; set; }

        public Office? Office { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        public string? PasswordSalt { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

    }
}
