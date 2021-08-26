using Microsoft.Practices.EnterpriseLibrary.Data;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Core;
using Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ICON_CUENTA_CONTABLERepository;
using Romsoft.GESTIONCLINICA.Entidades.CON_CUENTA_CONTABLE;
using System;
using System.Collections.Generic;
using System.Data;

namespace Romsoft.GESTIONCLINICA.DataAccess.Tablas
{
    public class CON_CUENTA_CONTABLERepository : Singleton<CON_CUENTA_CONTABLERepository>, ICON_CUENTA_CONTABLERepository<CON_CUENTA_CONTABLE>
    {
        #region Attributos

        private readonly Database _database = new DatabaseProviderFactory().Create(ConectionStringRepository.ConnectionStringNameSQL);

        #endregion

        public int Add(CON_CUENTA_CONTABLE entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(CON_CUENTA_CONTABLE entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(CON_CUENTA_CONTABLE entity)
        {
            throw new NotImplementedException();
        }

        public IList<CON_CUENTA_CONTABLE> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CON_CUENTA_CONTABLE> GetAllActives()
        {
            List<CON_CUENTA_CONTABLE> ctacontable = new List<CON_CUENTA_CONTABLE>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CON_CUENTA_CONTABLE_GetAllActives")))
            {
                //_database.AddInParameter(comando, "@tabla", DbType.String, entity.c_codigo);

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        ctacontable.Add(new CON_CUENTA_CONTABLE
                        {

                            id_cuenta_contable = lector.IsDBNull(lector.GetOrdinal("id_cuenta_contable")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_cuenta_contable")),
                            t_descripcion = lector.IsDBNull(lector.GetOrdinal("t_descripcion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion")),
                        });
                    }
                }
            }

            return ctacontable;
        }

        public IList<CON_CUENTA_CONTABLE> GetAllFilters(CON_CUENTA_CONTABLE entity)
        {
            throw new NotImplementedException();
        }

        public IList<CON_CUENTA_CONTABLE> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public CON_CUENTA_CONTABLE GetByEstado(string estadoNombre)
        {
            throw new NotImplementedException();
        }

        public IList<CON_CUENTA_CONTABLE> GetById(CON_CUENTA_CONTABLE entity)
        {
            throw new NotImplementedException();
        }

        public int Update(CON_CUENTA_CONTABLE entity)
        {
            throw new NotImplementedException();
        }
    }
}
