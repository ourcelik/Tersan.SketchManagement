using Tersan.SketchManagement.Infrastructure.Models.Base;

namespace Tersan.SketchManagement.Infrastructure.Models
{
    public class ShipStatus : BaseModel
    {
        public string? StatusType { get; set; }

        public ICollection<Ship>? Ships { get; set; }
    }

}
