using Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ILog;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Tablas;
using Romsoft.GESTIONCLINICA.Entidades;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Tablas
{
    public class LogBL : Singleton<LogBL>, ILogBL<Log>
    {
        public int Add(Log entity)
        {
            return LogRepository.Instancia.Add(entity);
        }
    }
}
