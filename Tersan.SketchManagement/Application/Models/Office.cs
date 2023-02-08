using Tersan.SketchManagement.Infrastructure.Models.Base;

namespace Tersan.SketchManagement.Infrastructure.Models
{
    public class Office : Point
    {
        public int BuildingID { get; set; }

        public Building? Building { get; set; }



        public int Floor { get; set; }

        public string? Name { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
