using Tersan.SketchManagement.Models.Base;

namespace Tersan.SketchManagement.Models
{
    public class Office : BaseModel
    {
        public int BuildingID { get; set; }

        public int PointID { get; set; }

        public int Floor { get; set; }

        public string? Name { get; set; }
    }
}
