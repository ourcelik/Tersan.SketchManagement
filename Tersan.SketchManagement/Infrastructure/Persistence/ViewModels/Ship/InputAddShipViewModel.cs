namespace Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Ship
{
    public class InputAddShipViewModel
    {
        public string? Name { get; set; }

        public int ShipStatusID { get; set; }

        public decimal X { get; set; }

        public decimal Y { get; set; }

        public int SketchID { get; set; }
    }
}
