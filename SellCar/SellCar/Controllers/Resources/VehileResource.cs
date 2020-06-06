using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SellCar.Controllers.Resources
{
    public class VehileResource
    {
        public int Id { get; set; }

        public KeyValuePairResource CarModel { get; set; }

        public KeyValuePairResource Make { get; set; }

        public bool IsRegistered { get; set; }

        public ContactResource Contact { get; set; }

        public DateTime LastUpdate { get; set; }

        public ICollection<KeyValuePairResource> Features { get; set; }

        public VehileResource()
        {
            Features = new Collection<KeyValuePairResource>();
        }
    }
}
