using Romsoft.GESTIONCLINICA.DataAccess.Core;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ICVN_CATEGORIA_PAGO_PRECIORepository
{
 
    public interface ICVN_CATEGORIA_PAGO_PRECIORepository<T> : IRepository<T>
    where T : class
    {
        bool Exists(T entity);
        T GetByEstado(string estadoNombre);
        IList<T> GetAllActivesFilters(T entity);

    }
}
