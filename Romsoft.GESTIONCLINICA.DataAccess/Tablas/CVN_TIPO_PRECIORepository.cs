using Microsoft.Practices.EnterpriseLibrary.Data;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Core;
using Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ICVN_TIPO_PRECIORepository;
using Romsoft.GESTIONCLINICA.Entidades.CVN_TIPO_PRECIO;
using System;
using System.Collections.Generic;
using System.Data;

namespace Romsoft.GESTIONCLINICA.DataAccess.Tablas
{
    public class CVN_TIPO_PRECIORepository : Singleton<CVN_TIPO_PRECIORepository>, ICVN_TIPO_PRECIORepository<CVN_TIPO_PRECIO>
    {
        #region Attributos

        private readonly Database _database = new DatabaseProviderFactory().Create(ConectionStringRepository.ConnectionStringNameSQL);

        #endregion

        public int Add(CVN_TIPO_PRECIO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(CVN_TIPO_PRECIO entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(CVN_TIPO_PRECIO entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TIPO_PRECIO> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TIPO_PRECIO> GetAllActives()
        {
            List<CVN_TIPO_PRECIO> precio = new List<CVN_TIPO_PRECIO>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_TIPO_PRECIO_GetAllActives")))
            {
                //_database.AddInParameter(comando, "@tabla", DbType.String, entity.c_codigo);

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        precio.Add(new CVN_TIPO_PRECIO
                        {

                            id_tipo_precio = lector.IsDBNull(lector.GetOrdinal("id_tipo_precio")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_tipo_precio")),
                            t_descripcion = lector.IsDBNull(lector.GetOrdinal("t_descripcion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion")),
                        });
                    }
                }
            }

            return precio;
        }

        public IList<CVN_TIPO_PRECIO> GetAllFilters(CVN_TIPO_PRECIO entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TIPO_PRECIO> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public CVN_TIPO_PRECIO GetByEstado(string estadoNombre)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TIPO_PRECIO> GetById(CVN_TIPO_PRECIO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(CVN_TIPO_PRECIO entity)
        {
            throw new NotImplementedException();
        }
    }
}
