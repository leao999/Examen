using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebLuisArrieta.Model;
using System.Data.Entity;

namespace WebLuisArrieta.Repositorio
{
    //public class WebLuisArrietaRepositorio : BaseRepositorio<Customer>
    //{

    //    public Customer GetById(int id)
    //    {
    //        using (var db = new WebContextDb())
    //        {
    //            return db.Customer.FirstOrDefault(p => p.Id==id);

    //        }

    //    }
    //}
    public class PersonRepository : BaseRepositorio<Customer>
    {
        public Customer GetById(int id)
        {
            using (var db = new WebContextDb())
            {
                return db.Customer.FirstOrDefault(p => p.Id == id);
            }
        }

        public List<Customer> GetListBySize(int size)
        {
            using (var db = new WebContextDb())
            {
                return db.Customer
                    .OrderByDescending(p => p.Order)
                    .Take(size).ToList();

            }
        }

        public Customer GetCompletePersonById(int id)
        {
            using (var db = new WebContextDb())
            {
                return db.Customer
                    .Include(p => p.Id)
                    .FirstOrDefault(p => p.Id == id);
            }
        }
    }
}
