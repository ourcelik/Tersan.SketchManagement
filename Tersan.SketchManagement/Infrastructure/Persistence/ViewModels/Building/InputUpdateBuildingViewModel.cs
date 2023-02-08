namespace Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Building
{
    public class InputUpdateBuildingViewModel
    {
        public InputUpdateBuildingViewModel() { }

        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal X { get; set; }

        public decimal Y { get; set; }

        public int WindowHeight { get; set; }

        public int WindowWidth { get; set; }

    }
}
