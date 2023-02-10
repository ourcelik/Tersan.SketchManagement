using Tersan.SketchManagement.Infrastructure.Models.Base;

namespace Tersan.SketchManagement.Infrastructure.Models
{
    public class Point : BaseModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string? HexColorCode { get; set; }
    }

}
