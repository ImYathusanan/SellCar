using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SellCar.Models
{
    public class Make
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CarModel> Models { get; set; }

        public Make()
        {
            Models = new Collection<CarModel>();
        }
    }
}
