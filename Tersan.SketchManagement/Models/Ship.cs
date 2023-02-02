using Tersan.SketchManagement.Models.Base;

namespace Tersan.SketchManagement.Models
{
    public class Ship : BaseModel
    {
        public int StatusID { get; set; }

        public int SketchID { get; set; }
        
        public int PointID { get; set; }
        
    }
}
