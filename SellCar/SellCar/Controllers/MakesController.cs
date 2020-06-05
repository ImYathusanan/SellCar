using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SellCar.Models;
using SellCar.Controllers.Resources;
using SellCar.Persistence;

namespace SellCar.Controllers
{
    [Route("api/makes")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly SellCarDbContext _context;
        private readonly IMapper _mapper;

        public MakesController(SellCarDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes =  await _context.Makes.Include(m => m.Models).ToListAsync();

            return _mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}
