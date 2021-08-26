using Romsoft.GESTIONCLINICA.Business.Logic.Core;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ISEG_ROLBL
{

    public interface ISEG_ROLBL<T> : ILogic<T> where T : class
    {
        bool Exists(T entity);
        T GetByRol(string rolNombre);

        IList<T> GetAllActives();
    }

}
