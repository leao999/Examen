using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLuisArrieta.Repositorio
{
    public interface IRepositorio<T>
    {
        int Agregar(Task entity);

        int Actualizar(Task emtity);

        int Borrar(Task entity);

    }
}
