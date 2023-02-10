namespace Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Building
{
    public class InputAddBuildingViewModel
    {
        public string? Name { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int SketchId { get; set; }

        public string? HexColorCode { get; set; }

    }
}
