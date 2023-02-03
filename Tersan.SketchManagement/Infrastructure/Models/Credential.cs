using Tersan.SketchManagement.Infrastructure.Models.Base;

namespace Tersan.SketchManagement.Infrastructure.Models
{
    public class Credential : BaseModel
    {
        public string? Type { get; set; }

        public ICollection<UserCredential>? UserCredentials { get; set; }

    }
}
