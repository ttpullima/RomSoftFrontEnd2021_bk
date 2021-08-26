using Microsoft.Practices.EnterpriseLibrary.Data;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Core;
using Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ICVN_CATEGORIA_PAGO_PRECIORepository;
using Romsoft.GESTIONCLINICA.Entidades.CVN_CATEGORIA_PAGO_PRECIO;
using System;
using System.Collections.Generic;
using System.Data;

namespace Romsoft.GESTIONCLINICA.DataAccess.Tablas
{
    public class CVN_CATEGORIA_PAGO_PRECIORepository : Singleton<CVN_CATEGORIA_PAGO_PRECIORepository>, ICVN_CATEGORIA_PAGO_PRECIORepository<CVN_CATEGORIA_PAGO_PRECIO>
    {
        #region Attributos

        private readonly Database _database = new DatabaseProviderFactory().Create(ConectionStringRepository.ConnectionStringNameSQL);


        #endregion

        public int Add(CVN_CATEGORIA_PAGO_PRECIO entity)
        {
            int id;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_CATEGORIA_PAGO_PRECIO_Insert")))
            {
                _database.AddInParameter(comando, "@id_categoria_pago", DbType.Int32, entity.id_categoria_pago);
                _database.AddInParameter(comando, "@id_tarifario_segus", DbType.Int32, entity.id_tarifario_segus);
                _database.AddInParameter(comando, "@n_precio_usd", DbType.Decimal, entity.n_precio_usd);
                _database.AddInParameter(comando, "@n_precio_sol", DbType.Decimal, entity.n_precio_sol);
                _database.AddInParameter(comando, "@id_user_registro", DbType.Int32, entity.id_usuarioCreacion);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                id = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return id;
        }

        public int Delete(CVN_CATEGORIA_PAGO_PRECIO entity)
        {
            int id;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_CATEGORIA_PAGO_PRECIO_Delete")))
            {
                _database.AddInParameter(comando, "@id_categoria_pago_precio", DbType.String, entity.id_categoria_pago_precio);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                id = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return id;
        }

        public bool Exists(CVN_CATEGORIA_PAGO_PRECIO entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CATEGORIA_PAGO_PRECIO> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CATEGORIA_PAGO_PRECIO> GetAllActives()
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CATEGORIA_PAGO_PRECIO> GetAllActivesFilters(CVN_CATEGORIA_PAGO_PRECIO entity)
        {
            List<CVN_CATEGORIA_PAGO_PRECIO> pagoprecio_segus = new List<CVN_CATEGORIA_PAGO_PRECIO>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_CATEGORIA_PAGO_PRECIO_GetAllActives")))
            {
                _database.AddInParameter(comando, "@id_tarifario_segus", DbType.Int32, entity.id_tarifario_segus);

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        pagoprecio_segus.Add(new CVN_CATEGORIA_PAGO_PRECIO
                        {
                            id_categoria_pago_precio = lector.IsDBNull(lector.GetOrdinal("id_categoria_pago_precio")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_categoria_pago_precio")),
                            id_tarifario_segus = lector.IsDBNull(lector.GetOrdinal("id_tarifario_segus")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_tarifario_segus")),
                            id_categoria_pago = lector.IsDBNull(lector.GetOrdinal("id_categoria_pago")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_categoria_pago")),
                            c_codigo = lector.IsDBNull(lector.GetOrdinal("c_codigo")) ? default(string) : lector.GetString(lector.GetOrdinal("c_codigo")),
                            t_descripcion = lector.IsDBNull(lector.GetOrdinal("t_descripcion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion")),
                            n_precio_sol = lector.IsDBNull(lector.GetOrdinal("n_precio_sol")) ? default(decimal) : lector.GetDecimal(lector.GetOrdinal("n_precio_sol")),
                            n_precio_usd = lector.IsDBNull(lector.GetOrdinal("n_precio_usd")) ? default(decimal) : lector.GetDecimal(lector.GetOrdinal("n_precio_usd")),
                        });
                    }
                }
            }

            return pagoprecio_segus;
        }

        public IList<CVN_CATEGORIA_PAGO_PRECIO> GetAllFilters(CVN_CATEGORIA_PAGO_PRECIO entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CATEGORIA_PAGO_PRECIO> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public CVN_CATEGORIA_PAGO_PRECIO GetByEstado(string estadoNombre)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CATEGORIA_PAGO_PRECIO> GetById(CVN_CATEGORIA_PAGO_PRECIO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(CVN_CATEGORIA_PAGO_PRECIO entity)
        {
            throw new NotImplementedException();
        }
    }
}
