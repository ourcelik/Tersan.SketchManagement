namespace Tersan.SketchManagement.Infrastructure.ViewModels.Ship
{
    public class ShipDeleteViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public bool IsDeleted { get; set; } = false;

    }
}
