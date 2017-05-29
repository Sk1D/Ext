using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCar.DAL.Interfaces
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T value);
        void Update(T value);
        void Delete(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        IEnumerable<T> Include();
    }
}
