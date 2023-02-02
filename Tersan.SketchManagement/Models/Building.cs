using Tersan.SketchManagement.Models.Base;

namespace Tersan.SketchManagement.Models
{
    public class Building : BaseModel
    {
        public int SketchID { get; set; }

        public int PointID { get; set; }
    }
}
