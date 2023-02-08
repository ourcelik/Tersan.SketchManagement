namespace Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Building
{
    public class InputBuildingViewModel
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int SketchId { get; set; }
        public decimal WindowHeight { get; set; }
        public decimal WindowWidth { get; set; }

    }
}
