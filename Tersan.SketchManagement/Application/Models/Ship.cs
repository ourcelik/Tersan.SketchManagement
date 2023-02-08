using Tersan.SketchManagement.Infrastructure.Models.Base;

namespace Tersan.SketchManagement.Infrastructure.Models
{
    public class Ship : Point
    {
        public string? Name { get; set; }

        public ShipStatus? ShipStatus { get; set; }
        
        public int ShipStatusID { get; set; }

        public Sketch? Sketch { get; set; }

        public int SketchID { get; set; }

    }
}
