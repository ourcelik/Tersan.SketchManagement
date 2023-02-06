namespace Tersan.SketchManagement.Infrastructure.ViewModels.Ship
{
    public class OutputShipViewModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int ShipStatusID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string? StatusType { get; set; }
    }
}
