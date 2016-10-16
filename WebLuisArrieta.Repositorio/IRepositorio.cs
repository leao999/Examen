using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebLuisArrieta.Repositorio
{
    public interface IRepositorio<T>
    {
        int Agregar(T entity);

        int Actualizar(T emtity);

        int Borrar(T entity);

        List<T> GetList();
        T GetById(Expression<Func<T, bool>> match);
        IEnumerable<T> OrderedListByDateAndSize(Expression<Func<T,
            DateTime>> match, int size);
        IEnumerable<T> PaginatedList(Expression<Func<T, DateTime>> match,
            int page, int size);
    }
}
