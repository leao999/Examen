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
        protected WebContextDb db;
        private WebContextDb @object;

        public BaseRepositorio()
        {
            db = new Repositorio.WebContextDb();
        }

        public BaseRepositorio(WebContextDb @object)
        {
            this.@object = @object;
        }

        public int Agregar(T entity)
        {
            
                db.Entry(entity).State = EntityState.Added;
                return db.SaveChanges();
            
        }

        public int Actualizar(T emtity)
        {
            throw new NotImplementedException();
        }

        public int Borrar(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(Expression<Func<T, bool>> match)
        {

            {
                return db.Set<T>().FirstOrDefault(match);
            }
        }

        public List<T> GetList()
        {
            using (var db = new WebContextDb())
            {
                return db.Set<T>().ToList();
            }
        }

        public IEnumerable<T> OrderedListByDateAndSize(Expression<Func<T, DateTime>> match, int size)
        {
            return db.Set<T>().OrderByDescending(match).Take(size);
        }

        public IEnumerable<T> PaginatedList(Expression<Func<T, DateTime>> match, int page, int size)
        {
            return db.Set<T>().OrderByDescending(match).Page(page, size);
        }

    }
}
