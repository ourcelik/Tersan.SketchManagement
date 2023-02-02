using Tersan.SketchManagement.Models.Base;

namespace Tersan.SketchManagement.Models
{
    public class UserCredential : BaseModel
    {
        public int EmployeeID { get; set; }

        public Employee? Employee { get; set; }

        public int CredentialID { get; set; }

        public Credential? Credential { get; set; }
    }
}
