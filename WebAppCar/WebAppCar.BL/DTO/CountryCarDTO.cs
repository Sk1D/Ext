using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCar.BL.DTO
{
    public class CountryCarDTO
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int CountryId { get; set; }
        public string Continent { get; set; }
        public string NameOfContry { get; set; }
    }
}
