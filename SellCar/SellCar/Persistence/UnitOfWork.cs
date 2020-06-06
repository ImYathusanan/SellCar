using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SellCar.Core;

namespace SellCar.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SellCarDbContext _context;

        public IVehileRepository Vehiles { get; private set; }

        public UnitOfWork(SellCarDbContext context)
        {
            _context = context;
            Vehiles = new VehileRepository(context);
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
