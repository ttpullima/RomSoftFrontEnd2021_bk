using Microsoft.Practices.EnterpriseLibrary.Data;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Core;
using Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ICVN_TARIFARIO_SEGUSRepository;
using Romsoft.GESTIONCLINICA.Entidades.CVN_TARIFARIO_SEGUS;
using System;
using System.Collections.Generic;
using System.Data;

namespace Romsoft.GESTIONCLINICA.DataAccess.Tablas
{
    public class CVN_TARIFARIO_SEGUSRepository : Singleton<CVN_TARIFARIO_SEGUSRepository>, ICVN_TARIFARIO_SEGUSRepository<CVN_TARIFARIO_SEGUS>
    {
        #region Attributos

        private readonly Database _database = new DatabaseProviderFactory().Create(ConectionStringRepository.ConnectionStringNameSQL);


        #endregion

        public int Add(CVN_TARIFARIO_SEGUS entity)
        {
            int id;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_TARIFARIO_SEGUS_Insert")))
            {
                _database.AddInParameter(comando, "@c_codigo", DbType.String, entity.c_codigo);
                _database.AddInParameter(comando, "@c_codigo_susalud", DbType.String, entity.c_codigo_susalud);
                _database.AddInParameter(comando, "@t_descripcion_esp", DbType.String, entity.t_descripcion_esp);
                _database.AddInParameter(comando, "@t_descripcion_eng", DbType.String, entity.t_descripcion_eng);
                _database.AddInParameter(comando, "@t_observacion", DbType.String, entity.t_observacion);
                _database.AddInParameter(comando, "@id_clasificacion_segus", DbType.String, entity.id_clasificacion_segus);
                _database.AddInParameter(comando, "@id_clasificacion_susalud", DbType.String, entity.id_clasificacion_susalud);
                _database.AddInParameter(comando, "@id_clasificacion_susalud_od", DbType.String, entity.id_clasificacion_susalud_od);
                _database.AddInParameter(comando, "@id_centro_costo", DbType.String, entity.id_centro_costo);
                _database.AddInParameter(comando, "@id_cuenta_contable", DbType.String, entity.id_cuenta_contable);
                _database.AddInParameter(comando, "@id_tipo_precio", DbType.String, entity.id_tipo_precio);
                _database.AddInParameter(comando, "@n_unidad", DbType.String, entity.n_unidad);
                _database.AddInParameter(comando, "@n_ayudante", DbType.String, entity.n_ayudante);
                _database.AddInParameter(comando, "@n_instrumentista", DbType.String, entity.n_instrumentista);
                _database.AddInParameter(comando, "@n_dias", DbType.String, entity.n_dias);
                _database.AddInParameter(comando, "@n_porcentaje", DbType.String, entity.n_porcentaje);
                _database.AddInParameter(comando, "@f_estado", DbType.Int32, entity.f_estado);
                _database.AddInParameter(comando, "@id_user_registro", DbType.Int32, entity.id_usuarioCreacion);
                _database.AddInParameter(comando, "@d_fecha_registro", DbType.DateTime, entity.FechaCreacion);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                id = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return id;
        }

        public int Delete(CVN_TARIFARIO_SEGUS entity)
        {
            int idResult;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_TARIFARIO_SEGUS_Delete")))
            {
                _database.AddInParameter(comando, "@id_tarifario_segus", DbType.Int32, entity.id_tarifario_segus);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                idResult = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return idResult;
        }

        public bool Exists(CVN_TARIFARIO_SEGUS entity)
        {
            bool existe = false;
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_TARIFARIO_SEGUS_VerifyExists")))
            {
                _database.AddInParameter(comando, "@c_codigo", DbType.String, entity.c_codigo);

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

        public IList<CVN_TARIFARIO_SEGUS> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TARIFARIO_SEGUS> GetAllActives()
        {
            List<CVN_TARIFARIO_SEGUS> tarifario_segus = new List<CVN_TARIFARIO_SEGUS>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_TARIFARIO_SEGUS_GetAllActives")))
            {
                           //_database.AddInParameter(comando, "@f_estado", DbType.Int32, entity.f_estado);

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        tarifario_segus.Add(new CVN_TARIFARIO_SEGUS
                        {

                            id_tarifario_segus = lector.IsDBNull(lector.GetOrdinal("id_tarifario_segus")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_tarifario_segus")),
                            c_codigo = lector.IsDBNull(lector.GetOrdinal("c_codigo")) ? default(string) : lector.GetString(lector.GetOrdinal("c_codigo")),
                            c_codigo_susalud = lector.IsDBNull(lector.GetOrdinal("c_codigo_susalud")) ? default(string) : lector.GetString(lector.GetOrdinal("c_codigo_susalud")),
                            t_descripcion_esp = lector.IsDBNull(lector.GetOrdinal("t_descripcion_esp")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion_esp")),
                            t_descripcion_eng = lector.IsDBNull(lector.GetOrdinal("t_descripcion_eng")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion_eng")),
                            t_observacion = lector.IsDBNull(lector.GetOrdinal("t_observacion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_observacion")),
                            t_clasificacion = lector.IsDBNull(lector.GetOrdinal("t_clasificacion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_clasificacion")),
                            estado = lector.IsDBNull(lector.GetOrdinal("estado")) ? default(string) : lector.GetString(lector.GetOrdinal("estado")),

                        });
                    }
                }
            }

            return tarifario_segus;
        }

        public IList<CVN_TARIFARIO_SEGUS> GetAllFilters(CVN_TARIFARIO_SEGUS entity)
        {
            List<CVN_TARIFARIO_SEGUS> tarifario_segus = new List<CVN_TARIFARIO_SEGUS>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_TARIFARIO_SEGUS_GetAllFilter")))
            {
                _database.AddInParameter(comando, "@valor", DbType.String, entity.valorRequest);
                
                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        tarifario_segus.Add(new CVN_TARIFARIO_SEGUS
                        {

                            id_tarifario_segus = lector.IsDBNull(lector.GetOrdinal("id_tarifario_segus")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_tarifario_segus")),
                            c_codigo = lector.IsDBNull(lector.GetOrdinal("c_codigo")) ? default(string) : lector.GetString(lector.GetOrdinal("c_codigo")),
                            c_codigo_susalud = lector.IsDBNull(lector.GetOrdinal("c_codigo_susalud")) ? default(string) : lector.GetString(lector.GetOrdinal("c_codigo_susalud")),
                            t_descripcion_esp = lector.IsDBNull(lector.GetOrdinal("t_descripcion_esp")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion_esp")),
                            t_descripcion_eng = lector.IsDBNull(lector.GetOrdinal("t_descripcion_eng")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion_eng")),
                            t_observacion = lector.IsDBNull(lector.GetOrdinal("t_observacion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_observacion")),
                            t_clasificacion = lector.IsDBNull(lector.GetOrdinal("t_clasificacion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_clasificacion")),
                            estado = lector.IsDBNull(lector.GetOrdinal("estado")) ? default(string) : lector.GetString(lector.GetOrdinal("estado")),

                        });
                    }
                }
            }

            return tarifario_segus;
        }

        public IList<CVN_TARIFARIO_SEGUS> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TARIFARIO_SEGUS> GetById(CVN_TARIFARIO_SEGUS entity)
        {
            List<CVN_TARIFARIO_SEGUS> tarifario_segus = new List<CVN_TARIFARIO_SEGUS>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_TARIFARIO_SEGUS_GetById")))
            {
                _database.AddInParameter(comando, "@id_tarifario_segus", DbType.Int32, entity.id_tarifario_segus);

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        tarifario_segus.Add(new CVN_TARIFARIO_SEGUS
                        {

                            id_tarifario_segus = lector.IsDBNull(lector.GetOrdinal("id_tarifario_segus")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_tarifario_segus")),
                            c_codigo = lector.IsDBNull(lector.GetOrdinal("c_codigo")) ? default(string) : lector.GetString(lector.GetOrdinal("c_codigo")),
                            c_codigo_susalud = lector.IsDBNull(lector.GetOrdinal("c_codigo_susalud")) ? default(string) : lector.GetString(lector.GetOrdinal("c_codigo_susalud")),
                            t_descripcion_esp = lector.IsDBNull(lector.GetOrdinal("t_descripcion_esp")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion_esp")),
                            t_observacion = lector.IsDBNull(lector.GetOrdinal("t_observacion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_observacion")),
                            id_clasificacion_segus = lector.IsDBNull(lector.GetOrdinal("id_clasificacion_segus")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_clasificacion_segus")),
                            id_clasificacion_susalud = lector.IsDBNull(lector.GetOrdinal("id_clasificacion_susalud")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_clasificacion_susalud")),
                            id_clasificacion_susalud_od = lector.IsDBNull(lector.GetOrdinal("id_clasificacion_susalud_od")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_clasificacion_susalud_od")),
                            id_centro_costo = lector.IsDBNull(lector.GetOrdinal("id_centro_costo")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_centro_costo")),
                            id_cuenta_contable = lector.IsDBNull(lector.GetOrdinal("id_cuenta_contable")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_cuenta_contable")),
                            id_tipo_precio = lector.IsDBNull(lector.GetOrdinal("id_tipo_precio")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_tipo_precio")),
                            n_unidad = lector.IsDBNull(lector.GetOrdinal("n_unidad")) ? default(decimal) : lector.GetDecimal(lector.GetOrdinal("n_unidad")),
                            n_ayudante = lector.IsDBNull(lector.GetOrdinal("n_ayudante")) ? default(int) : lector.GetInt32(lector.GetOrdinal("n_ayudante")),
                            n_instrumentista = lector.IsDBNull(lector.GetOrdinal("n_instrumentista")) ? default(int) : lector.GetInt32(lector.GetOrdinal("n_instrumentista")),
                            n_dias = lector.IsDBNull(lector.GetOrdinal("n_dias")) ? default(int) : lector.GetInt32(lector.GetOrdinal("n_dias")),
                            n_porcentaje = lector.IsDBNull(lector.GetOrdinal("n_porcentaje")) ? default(decimal) : lector.GetDecimal(lector.GetOrdinal("n_porcentaje")),
                            f_estado = lector.IsDBNull(lector.GetOrdinal("f_estado")) ? default(int) : lector.GetInt32(lector.GetOrdinal("f_estado")),
                            id_usuarioCreacion = lector.IsDBNull(lector.GetOrdinal("id_user_registro")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_user_registro")),
                            id_usuarioModifica = lector.IsDBNull(lector.GetOrdinal("id_user_modifica")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_user_modifica")),
                            //estado = lector.IsDBNull(lector.GetOrdinal("estado")) ? default(string) : lector.GetString(lector.GetOrdinal("estado")),
                            //UsuarioCreacion = lector.IsDBNull(lector.GetOrdinal("usuario_registro")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario_registro")),
                            FechaCreacion = lector.IsDBNull(lector.GetOrdinal("d_fecha_registro")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("d_fecha_registro")),
                            //UsuarioModificacion = lector.IsDBNull(lector.GetOrdinal("usuario_modifica")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario_modifica")),
                            FechaModificacion = lector.IsDBNull(lector.GetOrdinal("d_fecha_modifica")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("d_fecha_modifica"))

                        });
                    }
                }
            }

            return tarifario_segus;
        }

        public int Update(CVN_TARIFARIO_SEGUS entity)
        {
            int id;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_TARIFARIO_SEGUS_Update")))
            {
                _database.AddInParameter(comando, "@id_tarifario_segus", DbType.Int32, entity.id_tarifario_segus);
                _database.AddInParameter(comando, "@c_codigo", DbType.String, entity.c_codigo);
                _database.AddInParameter(comando, "@c_codigo_susalud", DbType.String, entity.c_codigo_susalud);
                _database.AddInParameter(comando, "@t_descripcion_esp", DbType.String, entity.t_descripcion_esp);
                _database.AddInParameter(comando, "@t_descripcion_eng", DbType.String, entity.t_descripcion_eng);
                _database.AddInParameter(comando, "@t_observacion", DbType.String, entity.t_observacion);
                _database.AddInParameter(comando, "@id_clasificacion_segus", DbType.String, entity.id_clasificacion_segus);
                _database.AddInParameter(comando, "@id_clasificacion_susalud", DbType.String, entity.id_clasificacion_susalud);
                _database.AddInParameter(comando, "@id_clasificacion_susalud_od", DbType.String, entity.id_clasificacion_susalud_od);
                _database.AddInParameter(comando, "@id_centro_costo", DbType.String, entity.id_centro_costo);
                _database.AddInParameter(comando, "@id_cuenta_contable", DbType.String, entity.id_cuenta_contable);
                _database.AddInParameter(comando, "@id_tipo_precio", DbType.String, entity.id_tipo_precio);
                _database.AddInParameter(comando, "@n_unidad", DbType.String, entity.n_unidad);
                _database.AddInParameter(comando, "@n_ayudante", DbType.String, entity.n_ayudante);
                _database.AddInParameter(comando, "@n_instrumentista", DbType.String, entity.n_instrumentista);
                _database.AddInParameter(comando, "@n_dias", DbType.String, entity.n_dias);
                _database.AddInParameter(comando, "@n_porcentaje", DbType.String, entity.n_porcentaje);
                _database.AddInParameter(comando, "@f_estado", DbType.Int32, entity.f_estado);
                _database.AddInParameter(comando, "@id_user_modifica", DbType.Int32, entity.id_usuarioModifica);
                _database.AddInParameter(comando, "@d_fecha_modifica", DbType.DateTime, entity.FechaModificacion);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                id = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return id;
        }
    }
}
