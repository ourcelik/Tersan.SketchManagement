using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Application.ViewModels;
using Tersan.SketchManagement.Infrastructure.Models;
using Tersan.SketchManagement.Infrastructure.ViewModels.Building;

namespace Tersan.SketchManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        IBuildingRepository _buildingRepository;

        public BuildingController(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<Building>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var result = await _buildingRepository.GetListAsync();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(Building), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _buildingRepository.GetAsync(x => x.ID == id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("GetSummary")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<BuildingSummaryViewModel>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSummaryForAll(InputBuildingViewModel inputBuildingViewModel)
        {
            
            var result = await _buildingRepository.GetAllSummaryAsync(
                (x) => (x.SketchID == inputBuildingViewModel.SketchId || inputBuildingViewModel.SketchId == 0),
                inputBuildingViewModel.PageSize,
                inputBuildingViewModel.PageIndex);

            if (result == null) return NotFound();

            return Ok(result);
        }


        [HttpPost()]
        [ProducesResponseType(typeof(Building),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Add(InputAddBuildingViewModel inputAddBuildingViewModel)
        {
            var mappedItem = new Building()
            {
                Name = inputAddBuildingViewModel.Name,
                SketchID = inputAddBuildingViewModel.SketchId,
                X = inputAddBuildingViewModel.X,
                Y = inputAddBuildingViewModel.Y
            };
            var result = await _buildingRepository.AddAsync(mappedItem);

            if (result == null) NoContent();

            return Ok(result);
        }


        [HttpPut()]
        [ProducesResponseType(typeof(Building),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(InputUpdateBuildingViewModel inputUpdateBuildingViewModel)
        {
            var buildingFromDb = await _buildingRepository.GetAsync((e)=>e.ID == inputUpdateBuildingViewModel.Id);

            if (buildingFromDb == null) return NotFound();
            
            buildingFromDb.X = inputUpdateBuildingViewModel.X != 0 ? inputUpdateBuildingViewModel.X : buildingFromDb.X;
            buildingFromDb.Y = inputUpdateBuildingViewModel.Y != 0 ? inputUpdateBuildingViewModel.Y : buildingFromDb.Y;

            buildingFromDb.Name = inputUpdateBuildingViewModel.Name != null ? inputUpdateBuildingViewModel.Name : buildingFromDb.Name;

            var updatedItem = _buildingRepository.Update(buildingFromDb);

            if (updatedItem == null) return BadRequest();


            return Ok(buildingFromDb);

        }


        [HttpDelete()]
        [ProducesResponseType(typeof(Building),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var buildingFromDb = await _buildingRepository.GetAsync((e) => e.ID == id);

            if (buildingFromDb == null) return NotFound();

            var deleted = await _buildingRepository.DeleteAsync(buildingFromDb);

            if (deleted == null) return BadRequest();

            return Ok(deleted);
        }








    }
}
