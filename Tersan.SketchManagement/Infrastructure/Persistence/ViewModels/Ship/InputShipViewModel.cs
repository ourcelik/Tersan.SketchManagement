namespace Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Ship
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

        public decimal X { get; set; }

        public decimal Y { get; set; }

    }
}
