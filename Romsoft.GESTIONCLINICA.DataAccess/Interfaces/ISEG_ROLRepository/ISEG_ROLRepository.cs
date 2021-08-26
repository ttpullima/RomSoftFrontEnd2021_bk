using Romsoft.GESTIONCLINICA.DataAccess.Core;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ISEG_ROLRepository
{
    public interface ISEG_ROLRepository<T> : IRepository<T>
        where T : class
    {
        bool Exists(T entity);
        T GetByRol(string rolNombre);
        

    }
}
