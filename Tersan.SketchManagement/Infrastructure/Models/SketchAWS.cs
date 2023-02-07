using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tersan.SketchManagement.Infrastructure.Models
{
    public class SketchAWS
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? File  { get; set; }

    }
}