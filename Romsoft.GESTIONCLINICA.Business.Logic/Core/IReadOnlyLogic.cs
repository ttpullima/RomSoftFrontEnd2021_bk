using Romsoft.GESTIONCLINICA.Common;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Core
{
    public interface IReadOnlyLogic<T> where T : class
    {
        IList<T> GetById(string whereFilters);
        IList<T> GetAllPaging(PaginationParameter paginationParameters);
        T GetById(T entity);
    }
}
