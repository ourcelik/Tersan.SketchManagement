using Tersan.SketchManagement.Models.Base;

namespace Tersan.SketchManagement.Models
{
    public class Credential : BaseModel
    {
        public string? Type { get; set; }

        public ICollection<UserCredential>? UserCredentials { get; set; }

    }
}
