using Romsoft.GESTIONCLINICA.DataAccess.Core;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ICVN_CLASIFICACION_SEGUSRepository
{

    public interface ICVN_CLASIFICACION_SEGUSRepository<T> : IRepository<T>
      where T : class
    {
        bool Exists(T entity);
        T GetByEstado(string estadoNombre);
        IList<T> GetAllActives();

    }
}
