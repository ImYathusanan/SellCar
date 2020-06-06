using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SellCar.Controllers.Resources;
using SellCar.Core;
using SellCar.Core.Models;
using SellCar.Persistence;

namespace SellCar.Controllers
{
    [Route("api/vehiles")]
    [ApiController]
    public class VehilesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehilesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehile([FromBody] SaveVehicleResource vehileResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehile = _mapper.Map<SaveVehicleResource, Vehile>(vehileResource);
            vehile.LastUpdate = DateTime.Now;

            _unitOfWork.Vehiles.Add(vehile);
            await _unitOfWork.CompleteAsync();

            vehile = await _unitOfWork.Vehiles.GetVehile(vehile.Id);

            var result = _mapper.Map<Vehile, VehileResource>(vehile);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehile(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehile = await _unitOfWork.Vehiles.GetVehile(id);

            if (vehile == null)
                return NotFound();
            
            _mapper.Map<SaveVehicleResource, Vehile>(vehicleResource, vehile);
            vehile.LastUpdate = DateTime.Now;

            await _unitOfWork.CompleteAsync();

            vehile = await _unitOfWork.Vehiles.GetVehile(vehile.Id);
            var result = _mapper.Map<Vehile, VehileResource>(vehile);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehile(int id)
        {
            var vehile = await _unitOfWork.Vehiles.GetVehile(id, includeRelated: false);

            if (vehile == null)
                return NotFound();

            _unitOfWork.Vehiles.Remove(vehile);
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehile(int id)
        {
            var vehile = await _unitOfWork.Vehiles.GetVehile(id);

            if (vehile == null)
                return NotFound();

            var vehileResource = _mapper.Map<Vehile, VehileResource>(vehile);

            return Ok(vehileResource);
        }
    }
}
