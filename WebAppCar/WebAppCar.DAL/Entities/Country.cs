using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCar.DAL.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Continent { get; set; }
        public string NameOfContry { get; set; }
        public ICollection<Car> Cars { get; set; }
        public Country()
        {
            Cars = new List<Car>();
        }
    }
}
