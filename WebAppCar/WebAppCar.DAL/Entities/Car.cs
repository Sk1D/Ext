using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCar.DAL.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public ICollection<Country> Countries { get; set; }
        public Car()
        {
            Countries = new List<Country>();
        }
    }
}
