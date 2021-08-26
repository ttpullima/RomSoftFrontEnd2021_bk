namespace Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ILogRepository
{
    public interface ILogRepository<T> where T : class
    {
        int Add(T entity);
    }
}
