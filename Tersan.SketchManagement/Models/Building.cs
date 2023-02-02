using Tersan.SketchManagement.Models.Base;

namespace Tersan.SketchManagement.Models
{
    public class Building : Point
    {
        
        public int SketchID { get; set; }

        public Sketch? Sketch { get; set; }
    }
}
