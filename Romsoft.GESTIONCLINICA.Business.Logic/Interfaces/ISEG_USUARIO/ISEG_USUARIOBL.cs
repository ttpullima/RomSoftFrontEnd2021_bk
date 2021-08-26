using Romsoft.GESTIONCLINICA.Business.Logic.Core;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ISEG_USUARIO
{

    public interface ISEG_USUARIOBL<T> : ILogic<T> where T : class
    {
        bool Exists(T entity);
        
        T GetByUsername(string username, string clave);
    }
}
