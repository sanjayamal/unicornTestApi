using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Repository
{
    public interface IRepository<T>
    {
        T createData(T obj);
        IEnumerable<T> GetAll();
        T GetById(int id);

        T updateData(T obj);
        bool DeleteById(int id);
       
    }
}
