using Tersan.SketchManagement.Models.Base;

namespace Tersan.SketchManagement.Models
{
    public class ShipStatus : BaseModel
    {
        public string? StatusType { get; set; }

        public ICollection<Ship>? Ships { get; set; }
    }
    
}
