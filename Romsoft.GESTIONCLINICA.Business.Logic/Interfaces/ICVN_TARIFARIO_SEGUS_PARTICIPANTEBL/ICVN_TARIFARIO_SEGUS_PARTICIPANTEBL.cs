using Romsoft.GESTIONCLINICA.Business.Logic.Core;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ICVN_TARIFARIO_SEGUS_PARTICIPANTEBL
{

    public interface ICVN_TARIFARIO_SEGUS_PARTICIPANTEBL<T> : ILogic<T> where T : class
    {
        bool Exists(T entity);

        IList<T> GetAllActivesFilters(T entity);
    }

}
