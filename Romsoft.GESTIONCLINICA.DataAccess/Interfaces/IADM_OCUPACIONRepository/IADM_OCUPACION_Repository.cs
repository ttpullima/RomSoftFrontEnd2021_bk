using Romsoft.GESTIONCLINICA.DataAccess.Core;

namespace Romsoft.GESTIONCLINICA.DataAccess.Interfaces.IADM_OCUPACIONRepository
{

    public interface IADM_OCUPACION_Repository<T> : IRepository<T>
       where T : class
    {
        bool Exists(T entity);
    }
}
