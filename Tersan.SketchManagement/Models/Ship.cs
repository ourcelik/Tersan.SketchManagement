using Tersan.SketchManagement.Models.Base;

namespace Tersan.SketchManagement.Models
{
    public class Ship : BaseModel
    {
        public ShipStatus? ShipStatus { get; set; }
        public int ShipStatusID { get; set; }

        public Sketch? Sketch { get; set; }
        
        public int SketchID { get; set; }

        public Point? Point { get; set; }
        public int PointID { get; set; }
        
    }
}
