using Romsoft.GESTIONCLINICA.DataAccess.Core;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ICVN_TARIFARIO_SEGUS_PARTICIPANTERepository
{

    public interface ICVN_TARIFARIO_SEGUS_PARTICIPANTERepository<T> : IRepository<T>
    where T : class
    {
        bool Exists(T entity);
        T GetByEstado(string estadoNombre);
        IList<T> GetAllActivesFilters(T entity);

    }
}
