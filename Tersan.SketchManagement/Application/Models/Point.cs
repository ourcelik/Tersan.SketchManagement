using Tersan.SketchManagement.Infrastructure.Models.Base;

namespace Tersan.SketchManagement.Infrastructure.Models
{
    public class Point : BaseModel
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }
    }

}
