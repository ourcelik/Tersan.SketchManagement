namespace Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Building
{
    public class BuildingSummaryViewModel
    {
        public int ID { get; set; }

        public string? Name { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public string? HexColorCode { get; set; }
    }
}
