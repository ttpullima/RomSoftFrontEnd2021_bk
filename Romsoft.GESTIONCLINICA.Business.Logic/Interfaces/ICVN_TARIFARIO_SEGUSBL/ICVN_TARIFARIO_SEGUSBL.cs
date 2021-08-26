using Romsoft.GESTIONCLINICA.Business.Logic.Core;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ICVN_TARIFARIO_SEGUSBL
{
    public interface ICVN_TARIFARIO_SEGUSBL<T> : ILogic<T> where T : class
    {
        bool Exists(T entity);
    }
}
