using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebLuisArrieta.Repositorio
{
    public class BaseRepositorio<T> : IRepositorio<T> where T : class

    {
        public int Agregar(Task entity)
        {
            throw new NotImplementedException();
        }

        public int Actualizar(Task emtity)
        {
            throw new NotImplementedException();
        }

        public int Borrar(Task entity)
        {
            throw new NotImplementedException();
        }
        public List<T> GetList()
        {
            using (var db = new WebContextDb())
            {
                return db.Set<T>().ToList();
            }
        }
    }
}
