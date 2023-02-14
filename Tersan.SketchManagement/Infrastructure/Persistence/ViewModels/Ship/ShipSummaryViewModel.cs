namespace Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Ship
{
    public class ShipSummaryViewModel
    {
        public string? Name { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public string? StatusType { get; set; }

        public string? HexColorCode { get; set; }

        public int Width { get; set; }
        
        public int Height { get; set; }
    }
}
