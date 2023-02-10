using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Application.ViewModels;
using Tersan.SketchManagement.Infrastructure.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Building;
using Tersan.SketchManagement.Infrastructure.Validation.Factory;
using FluentValidation;

namespace Tersan.SketchManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        IBuildingRepository _buildingRepository;

        ICustomValidatorFactory _validatorFactory;

        public BuildingController(IBuildingRepository buildingRepository, ICustomValidatorFactory validatorFactory)
        {
            _buildingRepository = buildingRepository;
            _validatorFactory = validatorFactory;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<OutputBuildingViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _buildingRepository.GetListAsync(include: (x) => x.Include(y => y.Sketch));

            if (result == null || !result.Data.Any())
                return NotFound();

            var newPaginatedItemsViewModel = new PaginatedItemsViewModel<OutputBuildingViewModel>(result.PageIndex, result.PageSize, result.Count, result.Data.Select(x => new OutputBuildingViewModel
            {
                ID = x.ID,
                Name = x.Name,
                SketchID = x.SketchID,
                X = x.X,
                Y = x.Y,
                HexColorCode = x.HexColorCode
            }).ToList());

            return Ok(newPaginatedItemsViewModel);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(OutputBuildingViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return BadRequest();

            var result = await _buildingRepository.GetAsync(x => x.ID == id, include: (x) => x.Include((y) => y.Sketch));

            if (result == null)
                return NotFound();

            var mappedResult = new OutputBuildingViewModel
            {
                ID = result.ID,
                Name = result.Name,
                SketchID = result.SketchID,
                X = result.X,
                Y = result.Y,
                HexColorCode = result.HexColorCode
            };

            return Ok(mappedResult);
        }

        [HttpPost("GetSummary")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<BuildingSummaryViewModel>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSummaryForAll(InputBuildingViewModel inputBuildingViewModel)
        {

            var validator = _validatorFactory.GetValidator<InputBuildingViewModel>();
            await validator.ValidateAndThrowAsync(inputBuildingViewModel);

            var result = await _buildingRepository.GetAllSummaryAsync(
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
            var validator = _validatorFactory.GetValidator<InputAddBuildingViewModel>();
            await validator.ValidateAndThrowAsync(inputAddBuildingViewModel);

            var mappedItemForDB = new Building()
            {
                Name = inputAddBuildingViewModel.Name,
                SketchID = inputAddBuildingViewModel.SketchId,
                X = inputAddBuildingViewModel.X,
                Y = inputAddBuildingViewModel.Y,
                HexColorCode = inputAddBuildingViewModel.HexColorCode
            };
            var result = await _buildingRepository.AddAsync(mappedItemForDB);

            if (result == null) NoContent();

            var mappedItem = new BuildingAddViewModel()
            {
                ID = result.ID,
                Name = result.Name,
                SketchID = result.SketchID,
                X = result.X,
                Y = result.Y,
                HexColorCode = result.HexColorCode,
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
            var validator = _validatorFactory.GetValidator<InputUpdateBuildingViewModel>();
            await validator.ValidateAndThrowAsync(inputUpdateBuildingViewModel);

            var buildingFromDb = await _buildingRepository.GetAsync((e)=>e.ID == inputUpdateBuildingViewModel.Id);

            if (buildingFromDb == null) return NotFound();
            
            buildingFromDb.X = inputUpdateBuildingViewModel.X != 0 ? inputUpdateBuildingViewModel.X : buildingFromDb.X;
            buildingFromDb.Y = inputUpdateBuildingViewModel.Y != 0 ? inputUpdateBuildingViewModel.Y : buildingFromDb.Y;

            buildingFromDb.Name = inputUpdateBuildingViewModel.Name ?? buildingFromDb.Name;

            buildingFromDb.HexColorCode = inputUpdateBuildingViewModel.HexColorCode ?? buildingFromDb.HexColorCode;

            var updatedItem = await _buildingRepository.UpdateAsync(buildingFromDb);

            if (updatedItem == null) return BadRequest();

            var mappedItem = new BuildingUpdateViewModel()
            {
                ID = updatedItem.ID,
                Name = updatedItem.Name,
                SketchID = updatedItem.SketchID,
                X = updatedItem.X,
                Y = updatedItem.Y,
                HexColorCode = updatedItem.HexColorCode,
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
            if (id == 0) return BadRequest();

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
                HexColorCode = deleted.HexColorCode,
                IsDeleted= true,
            };

            return Ok(mappedItem);
        }

    }
}
