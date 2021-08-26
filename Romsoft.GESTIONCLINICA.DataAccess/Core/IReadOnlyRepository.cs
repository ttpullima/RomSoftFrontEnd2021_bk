using Romsoft.GESTIONCLINICA.Common;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.DataAccess.Core
{
    public interface IReadOnlyRepository<T> where T : class
    {
        IList<T> GetAll(string whereFilters);
        IList<T> GetAllPaging(PaginationParameter paginationParameters);
        T GetById(T entity);
    }
}
