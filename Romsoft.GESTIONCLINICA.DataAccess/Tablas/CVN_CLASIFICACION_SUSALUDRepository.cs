using Microsoft.Practices.EnterpriseLibrary.Data;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Core;
using Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ICVN_CLASIFICACION_SUSALUDRepository;
using Romsoft.GESTIONCLINICA.Entidades.CVN_CLASIFICACION_SUSALUD;
using System;
using System.Collections.Generic;
using System.Data;

namespace Romsoft.GESTIONCLINICA.DataAccess.Tablas
{
    public class CVN_CLASIFICACION_SUSALUDRepository : Singleton<CVN_CLASIFICACION_SUSALUDRepository>, ICVN_CLASIFICACION_SUSALUDRepository<CVN_CLASIFICACION_SUSALUD>
    {
        #region Attributos

        private readonly Database _database = new DatabaseProviderFactory().Create(ConectionStringRepository.ConnectionStringNameSQL);

        #endregion

        public int Add(CVN_CLASIFICACION_SUSALUD entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(CVN_CLASIFICACION_SUSALUD entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(CVN_CLASIFICACION_SUSALUD entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SUSALUD> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SUSALUD> GetAllActives()
        {
            List<CVN_CLASIFICACION_SUSALUD> clasificacion = new List<CVN_CLASIFICACION_SUSALUD>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_CLASIFICACION_SUSALUD_GetAllActives")))
            {
                //_database.AddInParameter(comando, "@tabla", DbType.String, entity.c_codigo);

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        clasificacion.Add(new CVN_CLASIFICACION_SUSALUD
                        {

                            id_clasificacion_susalud = lector.IsDBNull(lector.GetOrdinal("id_clasificacion_susalud")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_clasificacion_susalud")),
                            t_descripcion = lector.IsDBNull(lector.GetOrdinal("t_descripcion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion")),
                        });
                    }
                }
            }

            return clasificacion;
        }

        public IList<CVN_CLASIFICACION_SUSALUD> GetAllFilters(CVN_CLASIFICACION_SUSALUD entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SUSALUD> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public CVN_CLASIFICACION_SUSALUD GetByEstado(string estadoNombre)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SUSALUD> GetById(CVN_CLASIFICACION_SUSALUD entity)
        {
            throw new NotImplementedException();
        }

        public int Update(CVN_CLASIFICACION_SUSALUD entity)
        {
            throw new NotImplementedException();
        }
    }
}
