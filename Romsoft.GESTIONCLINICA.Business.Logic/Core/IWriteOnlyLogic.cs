namespace Romsoft.GESTIONCLINICA.Business.Logic.Core
{
    public interface IWriteOnlyLogic<T> where T : class
    {
        int Add(T entity);
        int Delete(T entity);
        int Update(T entity);
    }
}
