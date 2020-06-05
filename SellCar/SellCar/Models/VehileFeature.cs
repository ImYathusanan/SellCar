using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellCar.Models
{
    public class VehileFeature
    {
        public int VehileId { get; set; }

        public int FeatureId { get; set; }

        public Vehile Vehile { get; set; }

        public Feature Feature { get; set; }
    }
}
