using Microsoft.Practices.EnterpriseLibrary.Data;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Core;
using Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ICVN_CATEGORIA_PAGORepository;
using Romsoft.GESTIONCLINICA.Entidades.CVN_CATEGORIA_PAGO;
using System;
using System.Collections.Generic;
using System.Data;

namespace Romsoft.GESTIONCLINICA.DataAccess.Tablas
{
    public class CVN_CATEGORIA_PAGORepository : Singleton<CVN_CATEGORIA_PAGORepository>, ICVN_CATEGORIA_PAGORepository<CVN_CATEGORIA_PAGO>
    {
        #region Attributos

        private readonly Database _database = new DatabaseProviderFactory().Create(ConectionStringRepository.ConnectionStringNameSQL);

        #endregion

        public int Add(CVN_CATEGORIA_PAGO entity)
        {
            int id;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_CATEGORIA_PAGO_Insert")))
            {
                _database.AddInParameter(comando, "@c_codigo", DbType.String, entity.c_codigo);
                _database.AddInParameter(comando, "@t_descripcion", DbType.String, entity.t_descripcion);
                _database.AddInParameter(comando, "@t_observacion", DbType.String, entity.t_observacion);
                _database.AddInParameter(comando, "@d_fecha_i_vigencia", DbType.DateTime, entity.d_fecha_i_vigencia);
                _database.AddInParameter(comando, "@d_fecha_f_vigencia", DbType.DateTime, entity.d_fecha_f_vigencia);
                _database.AddInParameter(comando, "@n_factor_servicio", DbType.Decimal, entity.n_factor_servicio);
                _database.AddInParameter(comando, "@n_factor_procedimiento", DbType.Decimal, entity.n_factor_procedimiento);
                _database.AddInParameter(comando, "@n_dscto_farmacia", DbType.Decimal, entity.n_dscto_farmacia);
                _database.AddInParameter(comando, "@f_estado", DbType.Int32, entity.f_estado);
                _database.AddInParameter(comando, "@id_user_registro", DbType.Int32, entity.id_usuarioCreacion);
                _database.AddInParameter(comando, "@d_fecha_registro", DbType.DateTime, entity.FechaCreacion);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                id = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return id;
        }

        public int Delete(CVN_CATEGORIA_PAGO entity)
        {
            int idResult;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_CATEGORIA_PAGO_Delete")))
            {
                _database.AddInParameter(comando, "@id_categoria_pago", DbType.Int32, entity.id_categoria_pago);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                idResult = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return idResult;
        }

        public bool Exists(CVN_CATEGORIA_PAGO entity)
        {
            bool existe = false;
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_CATEGORIA_PAGO_VerifyExists")))
            {
                _database.AddInParameter(comando, "@c_codigo", DbType.String, entity.c_codigo);
                _database.AddInParameter(comando, "@t_descripcion", DbType.String, entity.t_descripcion);

                using (var lector = _database.ExecuteReader(comando))
                {
                    if (lector.Read())
                    {
                        existe = Convert.ToBoolean(lector.GetInt32(0));
                    }
                }
            }

            return existe;
        }

        public IList<CVN_CATEGORIA_PAGO> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CATEGORIA_PAGO> GetAllActives()
        {
            List<CVN_CATEGORIA_PAGO> catpago = new List<CVN_CATEGORIA_PAGO>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_CATEGORIA_PAGO_GetAllActives")))
            {
                //_database.AddInParameter(comando, "@tabla", DbType.String, entity.c_codigo);

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        catpago.Add(new CVN_CATEGORIA_PAGO
                        {

                            id_categoria_pago = lector.IsDBNull(lector.GetOrdinal("id_categoria_pago")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_categoria_pago")),
                            c_codigo = lector.IsDBNull(lector.GetOrdinal("c_codigo")) ? default(string) : lector.GetString(lector.GetOrdinal("c_codigo")),
                            t_descripcion = lector.IsDBNull(lector.GetOrdinal("t_descripcion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion")),
                        });
                    }
                }
            }

            return catpago;
        }

        public IList<CVN_CATEGORIA_PAGO> GetAllFilters(CVN_CATEGORIA_PAGO entity)
        {
            List<CVN_CATEGORIA_PAGO> catpago = new List<CVN_CATEGORIA_PAGO>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_CATEGORIA_PAGO_GetAllFilter")))
            {
                _database.AddInParameter(comando, "@valor", DbType.String, entity.valorConsulta);

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        catpago.Add(new CVN_CATEGORIA_PAGO
                        {
                            id_categoria_pago = lector.IsDBNull(lector.GetOrdinal("id_categoria_pago")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_categoria_pago")),
                            c_codigo = lector.IsDBNull(lector.GetOrdinal("c_codigo")) ? default(string) : lector.GetString(lector.GetOrdinal("c_codigo")),
                            t_descripcion = lector.IsDBNull(lector.GetOrdinal("t_descripcion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion")),
                            t_observacion = lector.IsDBNull(lector.GetOrdinal("t_observacion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_observacion")),
                            d_fecha_f_vigencia = lector.IsDBNull(lector.GetOrdinal("d_fecha_f_vigencia")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("d_fecha_f_vigencia")),
                            f_estado = lector.IsDBNull(lector.GetOrdinal("f_estado")) ? default(int) : lector.GetInt32(lector.GetOrdinal("f_estado")),
                            estado = lector.IsDBNull(lector.GetOrdinal("estado")) ? default(string) : lector.GetString(lector.GetOrdinal("estado")),
                        });
                    }
                }
            }

            return catpago;
        }

        public IList<CVN_CATEGORIA_PAGO> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public CVN_CATEGORIA_PAGO GetByEstado(string estadoNombre)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CATEGORIA_PAGO> GetById(CVN_CATEGORIA_PAGO entity)
        {
            List<CVN_CATEGORIA_PAGO> categoriapago = new List<CVN_CATEGORIA_PAGO>();

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_CATEGORIA_PAGO_GetById")))
            {
                _database.AddInParameter(comando, "@id_caterogia_pago", DbType.Int32, entity.id_categoria_pago);

                using (var lector = _database.ExecuteReader(comando))
                {
                    if (lector.Read())
                    {
                        categoriapago.Add(new CVN_CATEGORIA_PAGO
                        {
                            id_categoria_pago = lector.IsDBNull(lector.GetOrdinal("id_categoria_pago")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_categoria_pago")),
                            c_codigo = lector.IsDBNull(lector.GetOrdinal("c_codigo")) ? default(string) : lector.GetString(lector.GetOrdinal("c_codigo")),
                            t_observacion = lector.IsDBNull(lector.GetOrdinal("t_observacion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_observacion")),
                            t_descripcion = lector.IsDBNull(lector.GetOrdinal("t_descripcion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion")),
                            d_fecha_i_vigencia = lector.IsDBNull(lector.GetOrdinal("d_fecha_i_vigencia")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("d_fecha_i_vigencia")),
                            d_fecha_f_vigencia = lector.IsDBNull(lector.GetOrdinal("d_fecha_f_vigencia")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("d_fecha_f_vigencia")),
                            n_factor_servicio = lector.IsDBNull(lector.GetOrdinal("n_factor_servicio")) ? default(decimal) : lector.GetDecimal(lector.GetOrdinal("n_factor_servicio")),
                            n_factor_procedimiento = lector.IsDBNull(lector.GetOrdinal("n_factor_procedimiento")) ? default(decimal) : lector.GetDecimal(lector.GetOrdinal("n_factor_procedimiento")),
                            n_dscto_farmacia = lector.IsDBNull(lector.GetOrdinal("n_dscto_farmacia")) ? default(decimal) : lector.GetDecimal(lector.GetOrdinal("n_dscto_farmacia")),
                            f_estado = lector.IsDBNull(lector.GetOrdinal("f_estado")) ? default(int) : lector.GetInt32(lector.GetOrdinal("f_estado")),
                            id_usuarioCreacion = lector.IsDBNull(lector.GetOrdinal("id_user_registro")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_user_registro")),
                            id_usuarioModifica = lector.IsDBNull(lector.GetOrdinal("id_user_modifica")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_user_modifica")),
                            FechaCreacion = lector.IsDBNull(lector.GetOrdinal("d_fecha_registro")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("d_fecha_registro")),
                            FechaModificacion = lector.IsDBNull(lector.GetOrdinal("d_fecha_modifica")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("d_fecha_modifica"))
                        });
                    }
                }
            }

            return categoriapago;
        }

        public int Update(CVN_CATEGORIA_PAGO entity)
        {
            int id;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_CATEGORIA_PAGO_Update")))
            {
                
                _database.AddInParameter(comando, "@id_categoria_pago", DbType.Int32, entity.id_categoria_pago);
                _database.AddInParameter(comando, "@c_codigo", DbType.String, entity.c_codigo);
                _database.AddInParameter(comando, "@t_descripcion", DbType.String, entity.t_descripcion);
                _database.AddInParameter(comando, "@t_observacion", DbType.String, entity.t_observacion);
                _database.AddInParameter(comando, "@d_fecha_i_vigencia", DbType.DateTime, entity.d_fecha_i_vigencia);
                _database.AddInParameter(comando, "@d_fecha_f_vigencia", DbType.DateTime, entity.d_fecha_f_vigencia);
                _database.AddInParameter(comando, "@n_factor_servicio", DbType.Decimal, entity.n_factor_servicio);
                _database.AddInParameter(comando, "@n_factor_procedimiento", DbType.Decimal, entity.n_factor_procedimiento);
                _database.AddInParameter(comando, "@n_dscto_farmacia", DbType.Decimal, entity.n_dscto_farmacia);
                _database.AddInParameter(comando, "@f_estado", DbType.Int32, entity.f_estado);
                _database.AddInParameter(comando, "id_user_modifica", DbType.Int32, entity.id_usuarioModifica);
                _database.AddInParameter(comando, "@d_fecha_modifica", DbType.DateTime, entity.FechaModificacion);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                id = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return id;
        }
    }
}
