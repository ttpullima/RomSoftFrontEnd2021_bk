using Romsoft.GESTIONCLINICA.Common;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Core
{
    public interface ILogic<T> where T : class
    {
        int Add(T entity);
        int Delete(T entity);
        IList<T> GetAll(string whereFilters);
        IList<T> GetAllPaging(PaginationParameter paginationParameters);
        IList<T> GetAllFilters(T entity);
        IList<T> GetById(T entity);
        int Update(T entity);
        IList<T> GetAllActives();

    }
}
