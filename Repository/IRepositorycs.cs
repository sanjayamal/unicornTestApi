using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Repository
{
    interface IRepositorycs<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);

        bool Delete(int id);
    }
}
