using Tersan.SketchManagement.Infrastructure.Persistence.Dtos;

namespace Tersan.SketchManagement.Infrastructure.Persistence.Repositories
{
    public static class ScaleHelperMethods
    {
        public static void ScaleSketchSizeToUserWindow(dynamic Entity,SizeDto windowSizeDto)
        {
            //TODO: Find a way to do this without dynamic
            Entity.X = (Entity.X / Entity.Sketch.Width) * windowSizeDto.Width;
            Entity.Y = (Entity.Y / Entity.Sketch.Height) * windowSizeDto.Height;

            //Entity.WindowWidth = windowSizeDto.Width;
            //Entity.WindowHeight = windowSizeDto.Height;
        }

        public static void ScalePointSizeToSketch(dynamic Entity, SizeDto windowSizeDto)
        {
            //TODO: Find a way to do this without dynamic
            Entity.X = (Entity.X / Entity.WindowWidth) * windowSizeDto.Width;
            Entity.Y = (Entity.Y / Entity.WindowHeight) * windowSizeDto.Height;

            //Entity.WindowWidth = windowSizeDto.Width;
            //Entity.WindowHeight = windowSizeDto.Height;
        }
    }
}
