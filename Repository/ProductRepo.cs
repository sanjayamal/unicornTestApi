using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.DataAccess;
using webApi.Models;

namespace webApi.Repository
{
    public class ProductRepo : IRepository<Product>
    {
        private readonly DataBaseContext _context;

        public ProductRepo(DataBaseContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
