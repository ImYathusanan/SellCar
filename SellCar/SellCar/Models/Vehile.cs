using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellCar.Models
{
    public class Vehile
    {
        public int Id { get; set; }

        public int ModelId { get; set; }
        public CarModel CarModel { get; set; }

        public bool IsRegistered { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactName { get; set; }

        [StringLength(255)]
        public string ContactEmail { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactPhone { get; set; }

        public DateTime LastUpdate { get; set; }

        public ICollection<VehileFeature> Features { get; set; }

        public Vehile()
        {
            Features = new Collection<VehileFeature>();
        }

    }
}
