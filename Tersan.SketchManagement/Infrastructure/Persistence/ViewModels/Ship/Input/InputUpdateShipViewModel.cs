namespace Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Ship
{
    public class InputUpdateShipViewModel
    {
        public int ID { get; set; }

        public string? Name { get; set; }

        public string? ShipStatusType { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public string? HexColorCode { get; set; }
    }
}
