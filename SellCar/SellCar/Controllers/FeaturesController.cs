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
    [Route("api/features")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {

        private readonly SellCarDbContext _context;
        private readonly IMapper _mapper;

        public FeaturesController(SellCarDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<FeatureResource>> GetFeatures()
        {
            var features = await _context.Features.ToListAsync();

            return _mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }
    }
}
