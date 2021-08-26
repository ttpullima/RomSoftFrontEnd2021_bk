namespace Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ILog
{
    public interface ILogBL<T> where T : class
    {
        int Add(T entity);
    }

}
