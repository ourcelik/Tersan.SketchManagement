using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tersan.SketchManagement.Infrastructure.Models;

namespace Tersan.SketchManagement.Application.Repositories.Abstracts
{
    public interface ISketchRepository : IAsyncRepository<Sketch>,IRepository<Sketch>
    {
        public Task<Sketch> UploadSketchAsync(SketchAWS sketch);
        public Task<Sketch> DeleteSketchAsync(string name);

    }
}