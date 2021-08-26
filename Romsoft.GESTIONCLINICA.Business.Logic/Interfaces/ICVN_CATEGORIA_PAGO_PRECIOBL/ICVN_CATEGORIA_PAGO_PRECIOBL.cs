using Romsoft.GESTIONCLINICA.Business.Logic.Core;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ICVN_CATEGORIA_PAGO_PRECIOBL
{

    public interface ICVN_CATEGORIA_PAGO_PRECIOBL<T> : ILogic<T> where T : class
    {
        bool Exists(T entity);

        IList<T> GetAllActivesFilters(T entity);
    }

}
