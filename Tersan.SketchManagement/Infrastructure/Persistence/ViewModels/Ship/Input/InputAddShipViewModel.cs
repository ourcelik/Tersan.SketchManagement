namespace Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Ship
{
    public class InputAddShipViewModel
    {
        public string? Name { get; set; }

        public int ShipStatusID { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int SketchID { get; set; }

        public string? HexColorCode { get; set; }

        public int Width { get; set; }
        
        public int Height { get; set; }
    }
}
