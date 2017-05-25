using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCar.DAL.Entities;

namespace WebAppCar.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Car> Cars { get; }
        IRepository<Country> Countries { get; }
        void Save();
    }
}
