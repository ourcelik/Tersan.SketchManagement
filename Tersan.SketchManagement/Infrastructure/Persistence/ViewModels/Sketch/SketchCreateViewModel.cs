using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Sketch
{
    public class SketchCreateViewModel
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

    }
}