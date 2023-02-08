using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Tersan.SketchManagement.Application.Repositories;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Application.ViewModels;
using Tersan.SketchManagement.Infrastructure.Models;
using Tersan.SketchManagement.Infrastructure.Persistence.Dtos;

namespace Tersan.SketchManagement.Infrastructure.Persistence.Repositories
{
    public class SketchRepository : EfBaseRepository<Sketch, SketchManagementDbContext>, ISketchRepository
    {
        IFileRepository _fileRepository;

        public SketchRepository(SketchManagementDbContext context, IFileRepository fileRepository) : base(context)
        {
            _fileRepository = fileRepository;
        }

        public async Task<Sketch> UploadSketchAsync(SketchDto sketch)
        {
            var sketchFromDb = await GetAsync((x) => x.Name == sketch.Name);

            await _fileRepository.UploadAsync("tersan-sketches", sketch.Name, sketch.File);

            if (sketchFromDb != null)
            {
                sketchFromDb.ImageUrl = $"https://tersan-sketches.s3.eu-central-1.amazonaws.com/{sketch.Name}";
                sketchFromDb.Description = sketch.Description;
                return await UpdateAsync(sketchFromDb);
            }

            return sketchFromDb ?? await AddAsync(new Sketch
            {
                Name = sketch.Name,
                Description = sketch.Description,
                ImageUrl = $"https://tersan-sketches.s3.eu-central-1.amazonaws.com/{sketch.Name}",
                Height = sketch.Height,
                Width = sketch.Width
            });
        }

        public async Task<Sketch> DeleteSketchAsync(string name)
        {
            var sketch = await GetAsync((x) => x.Name == name);

            if (sketch == null)
            {
                throw new Exception("Sketch not found");
            }

            await _fileRepository.DeleteAsync("tersan-sketches", name);
            
            var result = await DeleteAsync(sketch);
            
            return result;
        }

        public async Task<SizeDto> GetSizeAsync(Expression<Func<Sketch, bool>> predicate)
        {
            Sketch sketch = await GetAsync(predicate);

            if (sketch == null)
            {
                throw new Exception("Sketch not found");
            }

            return new SizeDto
            {
                Height = sketch.Height,
                Width = sketch.Width
            };
        }

    }

}