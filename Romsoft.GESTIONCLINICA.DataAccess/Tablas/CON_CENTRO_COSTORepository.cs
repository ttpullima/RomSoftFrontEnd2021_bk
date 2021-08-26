using Microsoft.Practices.EnterpriseLibrary.Data;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Core;
using Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ICON_CENTRO_COSTORepository;
using Romsoft.GESTIONCLINICA.Entidades.CON_CENTRO_COSTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace Romsoft.GESTIONCLINICA.DataAccess.Tablas
{
    public class CON_CENTRO_COSTORepository : Singleton<CON_CENTRO_COSTORepository>, ICON_CENTRO_COSTORepository<CON_CENTRO_COSTO>
    {
        #region Attributos

        private readonly Database _database = new DatabaseProviderFactory().Create(ConectionStringRepository.ConnectionStringNameSQL);

        #endregion

        public int Add(CON_CENTRO_COSTO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(CON_CENTRO_COSTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(CON_CENTRO_COSTO entity)
        {
            throw new NotImplementedException();
        }

        public IList<CON_CENTRO_COSTO> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CON_CENTRO_COSTO> GetAllActives()
        {
            List<CON_CENTRO_COSTO> centroCosto = new List<CON_CENTRO_COSTO>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CON_CENTRO_COSTO_GetAllActives")))
            {
                //_database.AddInParameter(comando, "@tabla", DbType.String, entity.c_codigo);

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        centroCosto.Add(new CON_CENTRO_COSTO
                        {

                            id_centro_costo = lector.IsDBNull(lector.GetOrdinal("id_centro_costo")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_centro_costo")),
                            t_descripcion = lector.IsDBNull(lector.GetOrdinal("t_descripcion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion")),
                        });
                    }
                }
            }

            return centroCosto;
        }

        public IList<CON_CENTRO_COSTO> GetAllFilters(CON_CENTRO_COSTO entity)
        {
            throw new NotImplementedException();
        }

        public IList<CON_CENTRO_COSTO> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public CON_CENTRO_COSTO GetByEstado(string estadoNombre)
        {
            throw new NotImplementedException();
        }

        public IList<CON_CENTRO_COSTO> GetById(CON_CENTRO_COSTO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(CON_CENTRO_COSTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
