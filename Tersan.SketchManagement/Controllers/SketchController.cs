using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Infrastructure.Models;
using Tersan.SketchManagement.Infrastructure.ViewModels.Sketch;

namespace Tersan.SketchManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SketchController : ControllerBase
    {
        ISketchRepository _sketchRepository;

        public SketchController(ISketchRepository sketchRepository)
        {
            _sketchRepository = sketchRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery]SketchCreateViewModel sketch,IFormFile file)
        {
            if (file == null)
            {
                return BadRequest();
            }
            var mappedSketch = new SketchAWS
            {
                Name = sketch.Name,
                Description = sketch.Description,
                File = file
            };
           
            var result =  await _sketchRepository.UploadSketchAsync(mappedSketch);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var result = await _sketchRepository.GetAsync((x) => x.Name == name);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _sketchRepository.GetListAsync();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string name)
        {
            var result = await _sketchRepository.DeleteSketchAsync(name);
            return Ok(result);
        }
    }
}