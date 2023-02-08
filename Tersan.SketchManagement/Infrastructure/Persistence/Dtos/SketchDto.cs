using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tersan.SketchManagement.Infrastructure.Persistence.Dtos
{
    public class SketchDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? File { get; set; }

    }
}