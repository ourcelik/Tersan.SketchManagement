using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Application.ViewModels;
using Tersan.SketchManagement.Infrastructure.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Building;
using Tersan.SketchManagement.Infrastructure.Persistence.Dtos;

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

        [HttpPost("GetAll")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<OutputBuildingViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(SizeDto windowSizeDto)
        {
            var result = await _buildingRepository.GetListAndScaleAsync(windowSizeDto,include: x => x.Include(y => y.Sketch));

            if (result == null || !result.Data.Any())
                return NotFound();

            var newPaginatedItemsViewModel = new PaginatedItemsViewModel<OutputBuildingViewModel>(result.PageIndex, result.PageSize, result.Count, result.Data.Select(x => new OutputBuildingViewModel
            {
                ID = x.ID,
                Name = x.Name,
                SketchID = x.SketchID,
                X = x.X,
                Y = x.Y,
            }).ToList());

            return Ok(newPaginatedItemsViewModel);
        }

        [HttpPost("Get")]
        [ProducesResponseType(typeof(OutputBuildingViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id,SizeDto sizeDto)
        {
            var result = await _buildingRepository.ScaleAndGetAsync((x)=> x.ID == id,sizeDto,include: x => x.Include(y => y.Sketch));

            if (result == null)
                return NotFound();

            var mappedResult = new OutputBuildingViewModel
            {
                ID = result.ID,
                Name = result.Name,
                SketchID = result.SketchID,
                X = result.X,
                Y = result.Y,
            };

            return Ok(result);
        }

        [HttpPost("GetSummary")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<BuildingSummaryViewModel>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSummaryForAll(InputBuildingViewModel inputBuildingViewModel)
        {
            SizeDto sizeDto = new SizeDto
            {
                Height = inputBuildingViewModel.WindowHeight,
                Width = inputBuildingViewModel.WindowWidth,
            };
            var result = await _buildingRepository.GetAllSummaryAsync(
                sizeDto,
                (x) => (x.SketchID == inputBuildingViewModel.SketchId || inputBuildingViewModel.SketchId == 0),
                inputBuildingViewModel.PageSize,
                inputBuildingViewModel.PageIndex);

            if (result == null || !result.Data.Any()) return NotFound();

            return Ok(result);
        }


        [HttpPost()]
        [ProducesResponseType(typeof(BuildingAddViewModel),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Add(InputAddBuildingViewModel inputAddBuildingViewModel)
        {
            var mappedItemForDB = new Building()
            {
                Name = inputAddBuildingViewModel.Name,
                SketchID = inputAddBuildingViewModel.SketchId,
                X = inputAddBuildingViewModel.X,
                Y = inputAddBuildingViewModel.Y,
                WindowHeight = inputAddBuildingViewModel.WindowHeight,
                WindowWidth = inputAddBuildingViewModel.WindowWidth,
            };
            var result = await _buildingRepository.AddAndScaleAsync(mappedItemForDB,(x)=> x.ID == mappedItemForDB.SketchID);

            if (result == null) NoContent();

            var mappedItem = new BuildingAddViewModel()
            {
                ID = result.ID,
                Name = result.Name,
                SketchID = result.SketchID,
                X = result.X,
                Y = result.Y,
                IsCreated = true,
            };

            return Ok(mappedItem);
        }


        [HttpPut()]
        [ProducesResponseType(typeof(BuildingUpdateViewModel),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(InputUpdateBuildingViewModel inputUpdateBuildingViewModel)
        {
            var buildingFromDb = await _buildingRepository.GetAsync((e)=>e.ID == inputUpdateBuildingViewModel.Id);

            if (buildingFromDb == null) return NotFound();
            
            buildingFromDb.X = inputUpdateBuildingViewModel.X != 0 ? inputUpdateBuildingViewModel.X : buildingFromDb.X;
            buildingFromDb.Y = inputUpdateBuildingViewModel.Y != 0 ? inputUpdateBuildingViewModel.Y : buildingFromDb.Y;

            buildingFromDb.Name = inputUpdateBuildingViewModel.Name != null ? inputUpdateBuildingViewModel.Name : buildingFromDb.Name;
            buildingFromDb.WindowHeight = inputUpdateBuildingViewModel.WindowHeight;
            buildingFromDb.WindowWidth = inputUpdateBuildingViewModel.WindowWidth;

            var updatedItem = await _buildingRepository.UpdateAndScaleAsync((x)=> x.ID == buildingFromDb.SketchID,buildingFromDb);
            

            if (updatedItem == null) return BadRequest();

            var mappedItem = new BuildingUpdateViewModel()
            {
                ID = updatedItem.ID,
                Name = updatedItem.Name,
                SketchID = updatedItem.SketchID,
                X = updatedItem.X,
                Y = updatedItem.Y,
                IsUpdated = true,
            };

            return Ok(mappedItem);

        }


        [HttpDelete()]
        [ProducesResponseType(typeof(OutputBuildingViewModel),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var buildingFromDb = await _buildingRepository.GetAsync((e) => e.ID == id);

            if (buildingFromDb == null) return NotFound();

            var deleted = await _buildingRepository.DeleteAsync(buildingFromDb);

            if (deleted == null) return BadRequest();

            var mappedItem = new BuildingDeleteViewModel()
            {
                ID = deleted.ID,
                Name = deleted.Name,
                SketchID = deleted.SketchID,
                X = deleted.X,
                Y = deleted.Y,
                IsDeleted= true,
            };

            return Ok(mappedItem);
        }

    }
}
