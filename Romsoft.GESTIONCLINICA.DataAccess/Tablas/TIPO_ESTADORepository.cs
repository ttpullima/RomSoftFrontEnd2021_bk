using Microsoft.Practices.EnterpriseLibrary.Data;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Core;
using Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ITIPO_ESTADO_Repository;
using Romsoft.GESTIONCLINICA.Entidades.TIPO_ESTADO;
using System;
using System.Collections.Generic;
using System.Data;

namespace Romsoft.GESTIONCLINICA.DataAccess.Tablas
{
    public class TIPO_ESTADORepository : Singleton<TIPO_ESTADORepository>, ITIPO_ESTADORepository<TIPO_ESTADO>
    {

        #region Attributos

        private readonly Database _database = new DatabaseProviderFactory().Create(ConectionStringRepository.ConnectionStringNameSQL);


        #endregion


        #region Métodos Públicos

        public int Add(TIPO_ESTADO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(TIPO_ESTADO entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(TIPO_ESTADO entity)
        {
            throw new NotImplementedException();
        }

        public IList<TIPO_ESTADO> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<TIPO_ESTADO> GetAllActives()
        {
            throw new NotImplementedException();
        }

        public IList<TIPO_ESTADO> GetAllFilters(TIPO_ESTADO entity)
        {
            List<TIPO_ESTADO> estados = new List<TIPO_ESTADO>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_TIPO_ESTADO_GetAllFilters")))
            {
                _database.AddInParameter(comando, "@tabla", DbType.String, entity.tabla);

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        estados.Add(new TIPO_ESTADO
                        {

                            id_estado = lector.IsDBNull(lector.GetOrdinal("id_estado")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_estado")),
                            estado = lector.IsDBNull(lector.GetOrdinal("estado")) ? default(string) : lector.GetString(lector.GetOrdinal("estado")),
                        });
                    }
                }
            }

            return estados;
        }

        public IList<TIPO_ESTADO> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public TIPO_ESTADO GetByEstado(string rolNombre)
        {
            throw new NotImplementedException();
        }

        public IList<TIPO_ESTADO> GetById(TIPO_ESTADO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(TIPO_ESTADO entity)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
