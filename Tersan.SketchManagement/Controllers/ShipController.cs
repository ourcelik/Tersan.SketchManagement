﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Application.ViewModels;
using Tersan.SketchManagement.Infrastructure.Models;
using Tersan.SketchManagement.Infrastructure.Persistence.Dtos;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Building;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Ship;

namespace Tersan.SketchManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipController : ControllerBase
    {
        private readonly IShipRepository _shipRepository;

        private readonly IShipStatusRepository _shipStatusRepository;

        public ShipController(IShipRepository shipRepository, IShipStatusRepository shipStatusRepository)
        {
            _shipRepository = shipRepository;
            this._shipStatusRepository = shipStatusRepository;
        }
        [HttpPost("GetAll")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<OutputShipViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(SizeDto windowSizeDto)
        {
            var result = await _shipRepository.GetListAndScaleAsync(windowSizeDto,include: (x) => x.Include(y => y.ShipStatus).Include(y => y.Sketch));

            if (result == null || !result.Data.Any())
                return NotFound();

            var newPaginatedItemsViewModel = new PaginatedItemsViewModel<OutputShipViewModel>(result.PageIndex, result.PageSize, result.Count, result.Data.Select(x => new OutputShipViewModel
            {
                Name = x.Name,
                X = x.X,
                Y = x.Y,
                StatusType = x.ShipStatus.StatusType,
                ShipStatusID = x.ShipStatusID,
                ID = x.ID
            }).ToList());

            return Ok(newPaginatedItemsViewModel);
        }

        [HttpPost("Get")]
        [ProducesResponseType(typeof(OutputShipViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id,SizeDto windowSizeDto)
        {
            var result = await _shipRepository.ScaleAndGetAsync(x => x.ID == id,windowSizeDto, include: (x) => x.Include((y) => y.Sketch).Include(y => y.ShipStatus));

            if (result == null)
                return NotFound();

            var mappedResult = new OutputShipViewModel
            {
                Name = result.Name,
                X = result.X,
                Y = result.Y,
                StatusType = result.ShipStatus.StatusType,
                ShipStatusID = result.ShipStatusID,
                ID = result.ID,
            };

            return Ok(mappedResult);
        }

        [HttpPost("GetSummary")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<ShipSummaryViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSummaryForAll(InputBuildingViewModel inputBuildingViewModel)
        {
            SizeDto size = new SizeDto
            {
                Height = inputBuildingViewModel.WindowHeight,
                Width = inputBuildingViewModel.WindowWidth
            };
            var result = await _shipRepository.GetAllSummaryAsync(
                size,
                (x) => (x.SketchID == inputBuildingViewModel.SketchId || inputBuildingViewModel.SketchId == 0),
                inputBuildingViewModel.PageSize,
                inputBuildingViewModel.PageIndex);

            if (result == null || !result.Data.Any()) return NotFound();

            return Ok(result);
        }


        [HttpPost()]
        [ProducesResponseType(typeof(ShipAddViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Add(InputAddShipViewModel inputAddShipViewModel)
        {
            var result = await _shipRepository.AddAndScaleAsync(new Ship
            {
                Name = inputAddShipViewModel.Name,
                X = inputAddShipViewModel.X,
                Y = inputAddShipViewModel.Y,
                SketchID = inputAddShipViewModel.SketchID,
                ShipStatusID = inputAddShipViewModel.ShipStatusID,
                WindowHeight = inputAddShipViewModel.WindowHeight,
                WindowWidth = inputAddShipViewModel.WindowWidth
            },
            (x) => x.ID == inputAddShipViewModel.SketchID
            );

            if (result == null) return NotFound();

            var mappedResult = new ShipAddViewModel()
            {
                ID = result.ID,
                Name = result.Name,
                X = result.X,
                Y = result.Y,
                StatusType = (await _shipStatusRepository.GetAsync((ss) => ss.ID == result.ShipStatusID)).StatusType,
                ShipStatusID = result.ShipStatusID,
                IsCreated = true,
            };

            return Ok(mappedResult);
        }

        [HttpPut()]
        [ProducesResponseType(typeof(ShipUpdateViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(InputUpdateShipViewModel inputUpdateShipViewModel)
        {
            ShipStatus? status = new();
            if (!String.IsNullOrEmpty(inputUpdateShipViewModel.ShipStatus))
            {
                status = await  _shipStatusRepository.GetAsync((ss) => ss.StatusType == inputUpdateShipViewModel.ShipStatus);

                if (status == null) return BadRequest("There is no StatusType like that you wrote");
            }
            
            var shipFromDb = await _shipRepository.GetAsync((e) => e.ID == inputUpdateShipViewModel.ID,include:(x) => x.Include(y => y.ShipStatus));

            shipFromDb.ShipStatusID = status.ID == default(int) ? shipFromDb.ShipStatusID : status.ID;

            if (shipFromDb == null) return NotFound();

            shipFromDb.X = inputUpdateShipViewModel.X != 0 ? inputUpdateShipViewModel.X : shipFromDb.X;
            shipFromDb.Y = inputUpdateShipViewModel.Y != 0 ? inputUpdateShipViewModel.Y : shipFromDb.Y;

            shipFromDb.Name = inputUpdateShipViewModel.Name != null ? inputUpdateShipViewModel.Name : shipFromDb.Name;

            var updatedItem = await _shipRepository.UpdateAndScaleAsync(x=>x.ID == shipFromDb.SketchID,shipFromDb);

            if (updatedItem == null) return BadRequest();

            var mappedShip = new ShipUpdateViewModel()
            {
                ID = updatedItem.ID,
                Name = updatedItem.Name,
                ShipStatusID = updatedItem.ShipStatusID,
                X = updatedItem.X,
                Y = updatedItem.Y,
                StatusType = updatedItem.ShipStatus.StatusType,
                IsUpdated = true,
            };

            return Ok(mappedShip);

        }


        [HttpDelete()]
        [ProducesResponseType(typeof(ShipDeleteViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var shipFromDb = await _shipRepository.GetAsync((e) => e.ID == id);

            if (shipFromDb == null) return NotFound();

            var deleted = await _shipRepository.DeleteAsync(shipFromDb);

            if (deleted == null) return BadRequest();

            var mappedShip = new ShipDeleteViewModel()
            {
                Id = shipFromDb.ID,
                Name = shipFromDb.Name,
                IsDeleted = true
            };
            
            return Ok(deleted);
        }
        
        
    }
}
