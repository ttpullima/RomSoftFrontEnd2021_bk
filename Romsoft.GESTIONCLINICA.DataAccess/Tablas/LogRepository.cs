using Microsoft.Practices.EnterpriseLibrary.Data;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Core;
using Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ILogRepository;
using Romsoft.GESTIONCLINICA.Entidades;
using Romsoft.GESTIONCLINICA.Entidades.SEG_ROL;
using System;
using System.Collections.Generic;
using System.Data;

namespace Romsoft.GESTIONCLINICA.DataAccess.Tablas
{
    public class LogRepository : Singleton<LogRepository>, ILogRepository<Log>
    {
        #region Attributos

        private readonly Database _database = new DatabaseProviderFactory().Create(ConectionStringRepository.ConnectionStringNameSQL);

        #endregion

        #region Métodos Públicos

        public int Add(Log entity)
        {
            int id;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "Log_Insert")))
            {
                comando.CommandTimeout = int.MaxValue;
                _database.AddInParameter(comando, "@DireccionIP", DbType.String, entity.DireccionIP);
                _database.AddInParameter(comando, "@Usuario", DbType.String, entity.Usuario);
                _database.AddInParameter(comando, "@Mensaje", DbType.String, entity.Mensaje);
                _database.AddInParameter(comando, "@Controlador", DbType.String, entity.Controlador);
                _database.AddInParameter(comando, "@Accion", DbType.String, entity.Accion);
                _database.AddInParameter(comando, "@Objeto", DbType.String, entity.Objeto);
                _database.AddInParameter(comando, "@Identificador", DbType.Int32, entity.Identificador);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                id = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return id;
        }

        #endregion
    }
}
