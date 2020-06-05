using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SellCar.Controllers.Resources;
using SellCar.Models;
using SellCar.Persistence;

namespace SellCar.Controllers
{
    [Route("api/vehiles")]
    [ApiController]
    public class VehilesController : ControllerBase
    {
        private readonly SellCarDbContext _context;
        private readonly IMapper _mapper;

        public VehilesController(SellCarDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehile([FromBody] VehicleResource vehileResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehile = _mapper.Map<VehicleResource, Vehile>(vehileResource);
            vehile.LastUpdate = DateTime.Now;

            _context.Vehiles.Add(vehile);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<Vehile, VehicleResource>(vehile);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehile(int id, [FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehile = await _context.Vehiles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);

            if (vehile == null)
                return NotFound();
            
            _mapper.Map<VehicleResource, Vehile>(vehicleResource, vehile);
            vehile.LastUpdate = DateTime.Now;

            await _context.SaveChangesAsync();

            var result = _mapper.Map<Vehile, VehicleResource>(vehile);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehile(int id)
        {
            var vehile = await _context.Vehiles.FindAsync(id);

            if (vehile == null)
                return NotFound();

            _context.Remove(vehile);
            await _context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehile(int id)
        {
            var vehile = await _context.Vehiles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);

            if (vehile == null)
                return NotFound();

            var vehileResource = _mapper.Map<Vehile, VehicleResource>(vehile);

            return Ok(vehileResource);
        }
    }
}
