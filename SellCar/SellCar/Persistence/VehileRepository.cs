using Microsoft.EntityFrameworkCore;
using SellCar.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SellCar.Core;

namespace SellCar.Persistence
{
    public class VehileRepository : IVehileRepository
    {
        private readonly SellCarDbContext _context;

        public VehileRepository(SellCarDbContext context)
        {
            _context = context;
        }

        public void Add(Vehile vehile)
        {
            _context.Add(vehile);
        }

        public void Remove(Vehile vehile)
        {
            _context.Remove(vehile);
        }

        public async Task<Vehile> GetVehile(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await _context.Vehiles.FindAsync(id);

            return await _context.Vehiles
                            .Include(v => v.Features)
                            .ThenInclude(vf => vf.Feature)
                            .Include(v => v.CarModel)
                            .ThenInclude(m => m.Make)
                            .SingleOrDefaultAsync(v => v.Id == id);
        }
    }
}
