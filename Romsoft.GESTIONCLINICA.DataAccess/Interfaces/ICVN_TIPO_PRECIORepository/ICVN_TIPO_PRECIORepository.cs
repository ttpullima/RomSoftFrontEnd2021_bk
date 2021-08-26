using Romsoft.GESTIONCLINICA.DataAccess.Core;
using System.Collections.Generic;


namespace Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ICVN_TIPO_PRECIORepository
{

    public interface ICVN_TIPO_PRECIORepository<T> : IRepository<T>
    where T : class
    {
        bool Exists(T entity);
        T GetByEstado(string estadoNombre);
        IList<T> GetAllActives();

    }
}
