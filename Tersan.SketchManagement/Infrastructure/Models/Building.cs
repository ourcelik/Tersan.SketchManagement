using Tersan.SketchManagement.Infrastructure.Models.Base;

namespace Tersan.SketchManagement.Infrastructure.Models
{
    public class Building : Point
    {
        public string? Name { get; set; }

        public int SketchID { get; set; }

        public Sketch? Sketch { get; set; }
    }
}
