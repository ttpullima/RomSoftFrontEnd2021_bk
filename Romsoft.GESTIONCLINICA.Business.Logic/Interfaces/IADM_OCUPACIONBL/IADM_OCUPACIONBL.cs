using Romsoft.GESTIONCLINICA.Business.Logic.Core;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.IADM_OCUPACIONBL
{

    public interface IADM_OCUPACIONBL<T> : ILogic<T> where T : class
    {
        bool Exists(T entity);

    }

}
