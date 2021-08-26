using Microsoft.Practices.EnterpriseLibrary.Data;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Core;
using Romsoft.GESTIONCLINICA.DataAccess.Interfaces.IADM_OCUPACIONRepository;
using Romsoft.GESTIONCLINICA.Entidades.ADM_OCUPACION;
using System;
using System.Collections.Generic;
using System.Data;

namespace Romsoft.GESTIONCLINICA.DataAccess.Tablas
{
    //class 
    public class ADM_OCUPACION_Repository : Singleton<ADM_OCUPACION_Repository>, IADM_OCUPACION_Repository<ADM_OCUPACION>
    {

        #region Attributos

        private readonly Database _database = new DatabaseProviderFactory().Create(ConectionStringRepository.ConnectionStringNameSQL);


        #endregion

        public int Add(ADM_OCUPACION entity)
        {
            int id;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_ADM_OCUPACION_Insert")))
            {
                _database.AddInParameter(comando, "@c_codigo", DbType.String, entity.c_codigo);
                _database.AddInParameter(comando, "@t_descripcion", DbType.String, entity.t_descripcion);
                _database.AddInParameter(comando, "@t_observacion", DbType.String, entity.t_observacion);
                _database.AddInParameter(comando, "@f_estado", DbType.Int32, entity.f_estado);
                _database.AddInParameter(comando, "@id_user_registro", DbType.Int32, entity.id_usuarioCreacion);
                _database.AddInParameter(comando, "@d_fecha_registro", DbType.DateTime, entity.FechaCreacion);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                id = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return id;
        }

        public int Delete(ADM_OCUPACION entity)
        {
            int idResult;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_ADM_OCUPACION_Delete")))
            {
                _database.AddInParameter(comando, "@id_ocupacion", DbType.Int32, entity.id_ocupacion);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                idResult = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return idResult;
        }

        public bool Exists(ADM_OCUPACION entity)
        {
            bool existe = false;
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_ADM_OCUPACION_VerifyExists")))
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

        public IList<ADM_OCUPACION> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<ADM_OCUPACION> GetAllActives()
        {
            List<ADM_OCUPACION> ocupacion = new List<ADM_OCUPACION>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_ADM_OCUPACION_GetAllActives")))
            {

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        ocupacion.Add(new ADM_OCUPACION
                        {
                            id_ocupacion = lector.IsDBNull(lector.GetOrdinal("id_ocupacion")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_ocupacion")),
                            c_codigo = lector.IsDBNull(lector.GetOrdinal("c_codigo")) ? default(string) : lector.GetString(lector.GetOrdinal("c_codigo")),
                            t_observacion = lector.IsDBNull(lector.GetOrdinal("t_observacion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_observacion")),
                            t_descripcion = lector.IsDBNull(lector.GetOrdinal("t_descripcion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion")),
                            f_estado = lector.IsDBNull(lector.GetOrdinal("f_estado")) ? default(int) : lector.GetInt32(lector.GetOrdinal("f_estado")),
                            id_usuarioCreacion = lector.IsDBNull(lector.GetOrdinal("id_usuarioCreacion")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_usuarioCreacion")),
                            id_usuarioModifica = lector.IsDBNull(lector.GetOrdinal("id_usuarioModifica")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_usuarioModifica")),
                            UsuarioCreacion = lector.IsDBNull(lector.GetOrdinal("UsuarioCreacion")) ? default(string) : lector.GetString(lector.GetOrdinal("UsuarioCreacion")),
                            UsuarioModificacion = lector.IsDBNull(lector.GetOrdinal("UsuarioModificacion")) ? default(string) : lector.GetString(lector.GetOrdinal("UsuarioModificacion")),
                        });
                    }
                }
            }

            return ocupacion;
        }

        public IList<ADM_OCUPACION> GetAllFilters(ADM_OCUPACION entity)
        {
            List<ADM_OCUPACION> estados = new List<ADM_OCUPACION>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_ADM_OCUPACION_GetAllFilter")))
            {
                _database.AddInParameter(comando, "@id_ocupacion", DbType.Int32, entity.id_ocupacion);
                _database.AddInParameter(comando, "@c_codigo", DbType.String, string.IsNullOrWhiteSpace(entity.c_codigo) ? string.Empty : entity.c_codigo);
                _database.AddInParameter(comando, "@t_descripcion", DbType.String, string.IsNullOrWhiteSpace(entity.t_descripcion) ? string.Empty : entity.t_descripcion);
                _database.AddInParameter(comando, "@f_estado", DbType.Int32, entity.f_estado);

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        estados.Add(new ADM_OCUPACION
                        {

                            id_ocupacion = lector.IsDBNull(lector.GetOrdinal("id_ocupacion")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_ocupacion")),
                            c_codigo = lector.IsDBNull(lector.GetOrdinal("c_codigo")) ? default(string) : lector.GetString(lector.GetOrdinal("c_codigo")),
                            t_observacion = lector.IsDBNull(lector.GetOrdinal("t_observacion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_observacion")),
                            t_descripcion = lector.IsDBNull(lector.GetOrdinal("t_descripcion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion")),
                            f_estado = lector.IsDBNull(lector.GetOrdinal("f_estado")) ? default(int) : lector.GetInt32(lector.GetOrdinal("f_estado")),
                            id_usuarioCreacion = lector.IsDBNull(lector.GetOrdinal("id_user_registro")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_user_registro")),
                            id_usuarioModifica = lector.IsDBNull(lector.GetOrdinal("id_user_modifica")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_user_modifica")),
                            estado = lector.IsDBNull(lector.GetOrdinal("estado")) ? default(string) : lector.GetString(lector.GetOrdinal("estado")),
                            UsuarioCreacion = lector.IsDBNull(lector.GetOrdinal("usuario_registro")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario_registro")),
                            FechaCreacion = lector.IsDBNull(lector.GetOrdinal("fecha_registro")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("fecha_registro")),
                            UsuarioModificacion = lector.IsDBNull(lector.GetOrdinal("usuario_modifica")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario_modifica")),
                            FechaModificacion = lector.IsDBNull(lector.GetOrdinal("fecha_modifica")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("fecha_modifica"))

                        });
                    }
                }
            }

            return estados;
        }

        public IList<ADM_OCUPACION> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public IList<ADM_OCUPACION> GetById(ADM_OCUPACION entity)
        {
            List<ADM_OCUPACION> ocupacion = new List<ADM_OCUPACION>();

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_ADM_OCUPACION_GetById")))
            {
                _database.AddInParameter(comando, "@id_ocupacion", DbType.Int32, entity.id_ocupacion);

                using (var lector = _database.ExecuteReader(comando))
                {
                    if (lector.Read())
                    {
                        ocupacion.Add(new ADM_OCUPACION
                        {
                            id_ocupacion = lector.IsDBNull(lector.GetOrdinal("id_ocupacion")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_ocupacion")),
                            c_codigo = lector.IsDBNull(lector.GetOrdinal("c_codigo")) ? default(string) : lector.GetString(lector.GetOrdinal("c_codigo")),
                            t_observacion = lector.IsDBNull(lector.GetOrdinal("t_observacion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_observacion")),
                            t_descripcion = lector.IsDBNull(lector.GetOrdinal("t_descripcion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion")),
                            f_estado = lector.IsDBNull(lector.GetOrdinal("f_estado")) ? default(int) : lector.GetInt32(lector.GetOrdinal("f_estado")),
                            estado = lector.IsDBNull(lector.GetOrdinal("estado")) ? default(string) : lector.GetString(lector.GetOrdinal("estado")),
                            id_usuarioCreacion = lector.IsDBNull(lector.GetOrdinal("id_user_registro")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_user_registro")),
                            id_usuarioModifica = lector.IsDBNull(lector.GetOrdinal("id_user_modifica")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_user_modifica")),
                            UsuarioCreacion = lector.IsDBNull(lector.GetOrdinal("usuario_registro")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario_registro")),
                            FechaCreacion = lector.IsDBNull(lector.GetOrdinal("fecha_registro")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("fecha_registro")),
                            UsuarioModificacion = lector.IsDBNull(lector.GetOrdinal("usuario_modifica")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario_modifica")),
                            FechaModificacion = lector.IsDBNull(lector.GetOrdinal("fecha_modifica")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("fecha_modifica"))
                        });
                    }
                }
            }

            return ocupacion;
        }

     
        public int Update(ADM_OCUPACION entity)
        {
            int id;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_ADM_OCUPACION_Update")))
            {
                //
                _database.AddInParameter(comando, "@id_ocupacion", DbType.String, entity.id_ocupacion);
                _database.AddInParameter(comando, "@c_codigo", DbType.String, entity.c_codigo);
                _database.AddInParameter(comando, "@t_descripcion", DbType.String, entity.t_descripcion);
                _database.AddInParameter(comando, "@t_observacion", DbType.String, entity.t_observacion);
                _database.AddInParameter(comando, "@f_estado", DbType.String, entity.f_estado);
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
