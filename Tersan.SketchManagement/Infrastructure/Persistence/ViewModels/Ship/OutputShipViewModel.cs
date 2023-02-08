namespace Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Ship
{
    public class OutputShipViewModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int ShipStatusID { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public string? StatusType { get; set; }
    }
}
