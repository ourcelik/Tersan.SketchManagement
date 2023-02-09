using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Application.ViewModels;
using Tersan.SketchManagement.Infrastructure.Models;
using Tersan.SketchManagement.Infrastructure.Persistence.Dtos;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Sketch;

namespace Tersan.SketchManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SketchController : ControllerBase
    {
        ISketchRepository _sketchRepository;
        IValidator<InputSketchCreateViewModel> _validator;

        public SketchController(ISketchRepository sketchRepository,IValidator<InputSketchCreateViewModel> validator)
        {
            _sketchRepository = sketchRepository;
            _validator = validator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Sketch), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromQuery]InputSketchCreateViewModel sketch,IFormFile file)
        {
            _validator.ValidateAndThrow(sketch);

            if (file == null)
            {
                return BadRequest();
            }
            var mappedSketch = new SketchDto
            {
                Name = sketch.Name,
                Description = sketch.Description,
                File = file
            };
           
            var result =  await _sketchRepository.UploadSketchAsync(mappedSketch);

            if(result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Sketch), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(string name)
        {
            if(string.IsNullOrEmpty(name))
                return BadRequest();

            var result = await _sketchRepository.GetAsync((x) => x.Name == name);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<Sketch>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _sketchRepository.GetListAsync();

            if (result == null || !result.Data.Any())
                return NotFound();

            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Sketch), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();
            var result = await _sketchRepository.DeleteSketchAsync(name);

            if (result == null)
                return NotFound();
        
            return Ok(result);
        }
    }
}