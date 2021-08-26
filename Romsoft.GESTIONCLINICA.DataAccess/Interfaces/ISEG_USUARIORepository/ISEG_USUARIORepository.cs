using Romsoft.GESTIONCLINICA.DataAccess.Core;

namespace Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ISEG_USUARIORepository
{

    public interface ISEG_USUARIORepository<T> : IRepository<T>
        where T : class
    {
        bool Exists(T entity);
        T GetByUsername(string username,string clave);
    }
}
