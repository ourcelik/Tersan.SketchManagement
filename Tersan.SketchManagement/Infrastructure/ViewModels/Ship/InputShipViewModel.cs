namespace Tersan.SketchManagement.Infrastructure.ViewModels.Ship
{
    public class InputShipViewModel
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int SketchId { get; set; }
    }

    public class InputUpdateShipViewModel
    {
        public int ID { get; set; }

        public string? Name { get; set; }

        public string? ShipStatus { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

    }
}
