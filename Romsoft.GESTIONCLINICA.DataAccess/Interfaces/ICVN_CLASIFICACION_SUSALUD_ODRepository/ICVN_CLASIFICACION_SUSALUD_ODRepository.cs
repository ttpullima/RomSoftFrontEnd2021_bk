using Romsoft.GESTIONCLINICA.DataAccess.Core;
using System.Collections.Generic;


namespace Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ICVN_CLASIFICACION_SUSALUD_ODRepository
{


    public interface ICVN_CLASIFICACION_SUSALUD_ODRepository<T> : IRepository<T>
      where T : class
    {
        bool Exists(T entity);
        T GetByEstado(string estadoNombre);
        IList<T> GetAllActives();

    }

}
