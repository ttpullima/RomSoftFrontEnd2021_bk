using Microsoft.Practices.EnterpriseLibrary.Data;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Core;
using Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ICVN_CLASIFICACION_SUSALUD_ODRepository;
using Romsoft.GESTIONCLINICA.Entidades.CVN_CLASIFICACION_SUSALUD_OD;
using System;
using System.Collections.Generic;
using System.Data;

namespace Romsoft.GESTIONCLINICA.DataAccess.Tablas
{
    public class CVN_CLASIFICACION_SUSALUD_ODRepository : Singleton<CVN_CLASIFICACION_SUSALUD_ODRepository>, ICVN_CLASIFICACION_SUSALUD_ODRepository<CVN_CLASIFICACION_SUSALUD_OD>
    {

        #region Attributos

        private readonly Database _database = new DatabaseProviderFactory().Create(ConectionStringRepository.ConnectionStringNameSQL);

        #endregion

        public int Add(CVN_CLASIFICACION_SUSALUD_OD entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(CVN_CLASIFICACION_SUSALUD_OD entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(CVN_CLASIFICACION_SUSALUD_OD entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SUSALUD_OD> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SUSALUD_OD> GetAllActives()
        {
            List<CVN_CLASIFICACION_SUSALUD_OD> susalud = new List<CVN_CLASIFICACION_SUSALUD_OD>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_CLASIFICACION_SUSALUD_OD_GetAllActives")))
            {
                //_database.AddInParameter(comando, "@tabla", DbType.String, entity.c_codigo);

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        susalud.Add(new CVN_CLASIFICACION_SUSALUD_OD
                        {

                            id_clasificacion_susalud_od = lector.IsDBNull(lector.GetOrdinal("id_clasificacion_susalud_od")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_clasificacion_susalud_od")),
                            t_descripcion = lector.IsDBNull(lector.GetOrdinal("t_descripcion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion")),
                        });
                    }
                }
            }

            return susalud;
        }

        public IList<CVN_CLASIFICACION_SUSALUD_OD> GetAllFilters(CVN_CLASIFICACION_SUSALUD_OD entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SUSALUD_OD> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public CVN_CLASIFICACION_SUSALUD_OD GetByEstado(string estadoNombre)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SUSALUD_OD> GetById(CVN_CLASIFICACION_SUSALUD_OD entity)
        {
            throw new NotImplementedException();
        }

        public int Update(CVN_CLASIFICACION_SUSALUD_OD entity)
        {
            throw new NotImplementedException();
        }
    }
}
