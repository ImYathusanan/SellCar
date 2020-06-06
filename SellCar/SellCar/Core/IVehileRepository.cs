using SellCar.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellCar.Core
{
    public interface IVehileRepository
    {
        Task<Vehile> GetVehile(int id, bool includeRelated = true);

        void Add(Vehile vehile);

        void Remove(Vehile vehile);
    }
}
