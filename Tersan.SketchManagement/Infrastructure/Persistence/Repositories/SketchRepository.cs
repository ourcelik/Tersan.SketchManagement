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

namespace Tersan.SketchManagement.Infrastructure.Persistence.Repositories
{
    public class SketchRepository : EfBaseRepository<Sketch, SketchManagementDbContext>, ISketchRepository
    {
        IAWSRepository _awsRepository;

        public SketchRepository(SketchManagementDbContext context, IAWSRepository awsRepository) : base(context)
        {
            _awsRepository = awsRepository;
        }

        public async Task<Sketch> UploadSketchAsync(SketchAWS sketch)
        {
            await _awsRepository.UploadAsync("tersan-sketches", sketch.Name, sketch.File);
            var result =  await AddAsync(new Sketch
            {
                Name = sketch.Name,
                Description = sketch.Description,
                ImageUrl = $"https://tersan-sketches.s3.eu-central-1.amazonaws.com/{sketch.Name}"
                
            });

            return result;
        }

        public async Task<Sketch> DeleteSketchAsync(string name)
        {
            var sketch = await GetAsync((x) => x.Name == name);
            
            await _awsRepository.DeleteAsync("tersan-sketches", name);
            
            var result = await DeleteAsync(sketch);
            
            return result;
        }

    }

}