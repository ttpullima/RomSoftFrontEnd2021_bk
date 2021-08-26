
using Microsoft.Practices.EnterpriseLibrary.Data;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Core;
using Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ISEG_USUARIORepository;
using Romsoft.GESTIONCLINICA.Entidades.SEG_USUARIO;
using System;
using System.Collections.Generic;
using System.Data;

namespace Romsoft.GESTIONCLINICA.DataAccess.Tablas
{
    public class SEG_USUARIORepository : Singleton<SEG_USUARIORepository>, ISEG_USUARIORepository<SEG_USUARIO>
    {
        #region Attributos

        private readonly Database _database = new DatabaseProviderFactory().Create(ConectionStringRepository.ConnectionStringNameSQL);
        

        #endregion

        #region Métodos Públicos

        public int Add(SEG_USUARIO entity)
        {
            int id;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_SEG_USUARIO_Insert")))
            {
                _database.AddInParameter(comando, "@id_rol", DbType.Int32, entity.id_rol);
                _database.AddInParameter(comando, "@usuario", DbType.String, entity.usuario);
                _database.AddInParameter(comando, "@clave", DbType.String, entity.clave);
                _database.AddInParameter(comando, "@apellidos", DbType.String, entity.apellidos);
                _database.AddInParameter(comando, "@nombres", DbType.String, entity.nombres);
                _database.AddInParameter(comando, "@nro_documento", DbType.String, entity.nro_documento);
                _database.AddInParameter(comando, "@sexo", DbType.String, entity.sexo);
                _database.AddInParameter(comando, "@email", DbType.String, entity.email);
                _database.AddInParameter(comando, "@celular", DbType.String, entity.celular);
                _database.AddInParameter(comando, "@estado", DbType.String, entity.estado);
                _database.AddInParameter(comando, "@usuario_registro", DbType.String, entity.UsuarioCreacion);
                _database.AddInParameter(comando, "@fecha_registro", DbType.DateTime, entity.FechaCreacion);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                id = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return id;
        }

        public int Delete(SEG_USUARIO entity)
        {
            int idResult;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_SEG_USUARIO_Delete")))
            {
                _database.AddInParameter(comando, "@id_usuario", DbType.Int32, entity.id_usuario);
                _database.AddInParameter(comando, "@usuario_modifica", DbType.String, entity.UsuarioModificacion); ////
                _database.AddInParameter(comando, "@fecha_modifica", DbType.String, entity.FechaModificacion); 
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                idResult = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return idResult;
        }

        public bool Exists(SEG_USUARIO entity)
        {
            bool existe = false;
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_SEG_USUARIOVerifyExists")))
            {
                _database.AddInParameter(comando, "@Username", DbType.String, entity.usuario);

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

        public IList<SEG_USUARIO> GetAllPaging(PaginationParameter paginationParameters)
        {
            List<SEG_USUARIO> usuarios = new List<SEG_USUARIO>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_SEG_USUARIO_GetAll")))
            {
                _database.AddInParameter(comando, "@WhereFilters", DbType.String, string.IsNullOrWhiteSpace(paginationParameters.WhereFilter) ? string.Empty : paginationParameters.WhereFilter);
                _database.AddInParameter(comando, "@OrderBy", DbType.String, string.IsNullOrWhiteSpace(paginationParameters.OrderBy) ? string.Empty : paginationParameters.OrderBy);
                _database.AddInParameter(comando, "@Start", DbType.Int32, paginationParameters.Start);
                _database.AddInParameter(comando, "@Rows", DbType.Int32, paginationParameters.AmountRows);

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        usuarios.Add(new SEG_USUARIO
                        {
                            id_usuario = lector.IsDBNull(lector.GetOrdinal("id_usuario")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_usuario")),
                            id_rol = lector.IsDBNull(lector.GetOrdinal("RolId")) ? default(int) : lector.GetInt32(lector.GetOrdinal("RolId")),
                            RolNombre= lector.IsDBNull(lector.GetOrdinal("RolNombre")) ? default(string) : lector.GetString(lector.GetOrdinal("RolNombre")),
                            usuario = lector.IsDBNull(lector.GetOrdinal("usuario")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario")),
                            //clave = lector.IsDBNull(lector.GetOrdinal("clave")) ? default(string) : lector.GetString(lector.GetOrdinal("clave")),
                            nombres = lector.IsDBNull(lector.GetOrdinal("nombres")) ? default(string) : lector.GetString(lector.GetOrdinal("nombres")),
                            apellidos = lector.IsDBNull(lector.GetOrdinal("apellidos")) ? default(string) : lector.GetString(lector.GetOrdinal("apellidos")),
                            nro_documento = lector.IsDBNull(lector.GetOrdinal("nro_documento")) ? default(string) : lector.GetString(lector.GetOrdinal("nro_documento")),
                            sexo= lector.IsDBNull(lector.GetOrdinal("sexo")) ? default(string) : lector.GetString(lector.GetOrdinal("sexo")),
                            email = lector.IsDBNull(lector.GetOrdinal("email")) ? default(string) : lector.GetString(lector.GetOrdinal("email")),
                            celular = lector.IsDBNull(lector.GetOrdinal("celular")) ? default(string) : lector.GetString(lector.GetOrdinal("celular")),
                            estado = lector.IsDBNull(lector.GetOrdinal("estado")) ? default(string) : lector.GetString(lector.GetOrdinal("estado")),
                            Cantidad = lector.IsDBNull(lector.GetOrdinal("Cantidad")) ? default(int) : lector.GetInt32(lector.GetOrdinal("Cantidad")),
                            UsuarioCreacion = lector.IsDBNull(lector.GetOrdinal("usuario_registro")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario_registro")),
                            FechaCreacion = lector.IsDBNull(lector.GetOrdinal("fecha_registro")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("fecha_registro")),
                            UsuarioModificacion = lector.IsDBNull(lector.GetOrdinal("usuario_modifica")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario_modifica")),
                            FechaModificacion = lector.IsDBNull(lector.GetOrdinal("fecha_modifica")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("fecha_modifica"))
                        });
                    }
                }
            }

            return usuarios;
        }

        public IList<SEG_USUARIO> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<SEG_USUARIO> GetById(SEG_USUARIO entity)
        {
            List<SEG_USUARIO> usuario = new List<SEG_USUARIO>();

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_SEG_USUARIO_GetById")))
            {
                _database.AddInParameter(comando, "@id_usuario", DbType.Int32, entity.id_usuario);

                using (var lector = _database.ExecuteReader(comando))
                {
                    if (lector.Read())
                    {
                        usuario.Add( new SEG_USUARIO
                        {
                            id_usuario = lector.IsDBNull(lector.GetOrdinal("id_usuario")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_usuario")),
                            id_rol = lector.IsDBNull(lector.GetOrdinal("RolId")) ? default(int) : lector.GetInt32(lector.GetOrdinal("RolId")),
                            RolNombre = lector.IsDBNull(lector.GetOrdinal("RolNombre")) ? default(string) : lector.GetString(lector.GetOrdinal("RolNombre")),
                            usuario = lector.IsDBNull(lector.GetOrdinal("usuario")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario")),
                            clave = lector.IsDBNull(lector.GetOrdinal("clave")) ? default(string) : lector.GetString(lector.GetOrdinal("clave")),
                            nombres = lector.IsDBNull(lector.GetOrdinal("nombres")) ? default(string) : lector.GetString(lector.GetOrdinal("nombres")),
                            apellidos = lector.IsDBNull(lector.GetOrdinal("apellidos")) ? default(string) : lector.GetString(lector.GetOrdinal("apellidos")),
                            nro_documento = lector.IsDBNull(lector.GetOrdinal("nro_documento")) ? default(string) : lector.GetString(lector.GetOrdinal("nro_documento")),
                            sexo = lector.IsDBNull(lector.GetOrdinal("sexo")) ? default(string) : lector.GetString(lector.GetOrdinal("sexo")),
                            email = lector.IsDBNull(lector.GetOrdinal("email")) ? default(string) : lector.GetString(lector.GetOrdinal("email")),
                            celular = lector.IsDBNull(lector.GetOrdinal("celular")) ? default(string) : lector.GetString(lector.GetOrdinal("celular")),
                            estado = lector.IsDBNull(lector.GetOrdinal("estado")) ? default(string) : lector.GetString(lector.GetOrdinal("estado")),
                            Cantidad = 0, //lector.IsDBNull(lector.GetOrdinal("Cantidad")) ? default(int) : lector.GetInt32(lector.GetOrdinal("Cantidad")),
                            UsuarioCreacion= lector.IsDBNull(lector.GetOrdinal("usuario_registro")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario_registro")),
                            FechaCreacion = lector.IsDBNull(lector.GetOrdinal("fecha_registro")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("fecha_registro")),
                            UsuarioModificacion = lector.IsDBNull(lector.GetOrdinal("usuario_modifica")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario_modifica")),
                            FechaModificacion = lector.IsDBNull(lector.GetOrdinal("fecha_modifica")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("fecha_modifica"))

                        });
                    }
                }
            }

            return usuario;
        }

        public SEG_USUARIO GetByUsername(string username,string clave)
        {
            SEG_USUARIO usuario = null;
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_SEG_USUARIOGetByUsernameClave")))
            {
                _database.AddInParameter(comando, "@Username", DbType.String, username);
                _database.AddInParameter(comando, "@clave", DbType.String, clave);

                using (var lector = _database.ExecuteReader(comando))
                {
                    if (lector.Read())
                    {
                        usuario = new SEG_USUARIO
                        {
                            id_usuario = lector.IsDBNull(lector.GetOrdinal("id_usuario")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_usuario")),
                            id_rol = lector.IsDBNull(lector.GetOrdinal("id_rol")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_rol")),
                            nombres = lector.IsDBNull(lector.GetOrdinal("nombres")) ? default(string) : lector.GetString(lector.GetOrdinal("nombres")),
                            apellidos = lector.IsDBNull(lector.GetOrdinal("apellidos")) ? default(string) : lector.GetString(lector.GetOrdinal("apellidos")),
                            estado = lector.IsDBNull(lector.GetOrdinal("estado")) ? default(string) : lector.GetString(lector.GetOrdinal("estado"))
                        };
                    }
                }
            }

            return usuario;
        }

        public int Update(SEG_USUARIO entity)
        {
            int id;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_SEG_USUARIO_Update")))
            {
                _database.AddInParameter(comando, "@id_usuario", DbType.Int32, entity.id_usuario);
                _database.AddInParameter(comando, "@id_rol", DbType.Int32, entity.id_rol);
                _database.AddInParameter(comando, "@usuario", DbType.String, entity.usuario);
                _database.AddInParameter(comando, "@clave", DbType.String, entity.clave);
                _database.AddInParameter(comando, "@apellidos", DbType.String, entity.apellidos);
                _database.AddInParameter(comando, "@nombres", DbType.String, entity.nombres);
                _database.AddInParameter(comando, "@nro_documento", DbType.String, entity.nro_documento);
                _database.AddInParameter(comando, "@sexo", DbType.String, entity.sexo);
                _database.AddInParameter(comando, "@email", DbType.String, entity.email);
                _database.AddInParameter(comando, "@celular", DbType.String, entity.celular);
                _database.AddInParameter(comando, "@estado", DbType.String, entity.estado);
                _database.AddInParameter(comando, "@usuario_modifica", DbType.String, entity.UsuarioModificacion); 
                _database.AddInParameter(comando, "@fecha_modifica", DbType.DateTime, entity.FechaModificacion);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                id = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return id;
        }

        public IList<SEG_USUARIO> GetAllFilters(SEG_USUARIO entity)
        {
            List<SEG_USUARIO> usuarios = new List<SEG_USUARIO>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_SEG_USUARIO_GetAllFilter")))
            {
                _database.AddInParameter(comando, "@id_rol", DbType.Int32, entity.id_rol);
                _database.AddInParameter(comando, "@apellidos", DbType.String, string.IsNullOrWhiteSpace(entity.apellidos) ? string.Empty : entity.apellidos);
                _database.AddInParameter(comando, "@usuario", DbType.String, string.IsNullOrWhiteSpace(entity.usuario) ? string.Empty : entity.usuario);
                _database.AddInParameter(comando, "@nro_documento", DbType.String, string.IsNullOrWhiteSpace(entity.nro_documento) ? string.Empty : entity.nro_documento);
                _database.AddInParameter(comando, "@estado", DbType.String, string.IsNullOrWhiteSpace(entity.estado) ? string.Empty : entity.estado);

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        usuarios.Add(new SEG_USUARIO
                        {
                            id_usuario = lector.IsDBNull(lector.GetOrdinal("id_usuario")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_usuario")),
                            id_rol = lector.IsDBNull(lector.GetOrdinal("RolId")) ? default(int) : lector.GetInt32(lector.GetOrdinal("RolId")),
                            RolNombre = lector.IsDBNull(lector.GetOrdinal("RolNombre")) ? default(string) : lector.GetString(lector.GetOrdinal("RolNombre")),
                            usuario = lector.IsDBNull(lector.GetOrdinal("usuario")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario")),
                            //clave = lector.IsDBNull(lector.GetOrdinal("clave")) ? default(string) : lector.GetString(lector.GetOrdinal("clave")),
                            nombres = lector.IsDBNull(lector.GetOrdinal("nombres")) ? default(string) : lector.GetString(lector.GetOrdinal("nombres")),
                            apellidos = lector.IsDBNull(lector.GetOrdinal("apellidos")) ? default(string) : lector.GetString(lector.GetOrdinal("apellidos")),
                            nro_documento = lector.IsDBNull(lector.GetOrdinal("nro_documento")) ? default(string) : lector.GetString(lector.GetOrdinal("nro_documento")),
                            sexo = lector.IsDBNull(lector.GetOrdinal("sexo")) ? default(string) : lector.GetString(lector.GetOrdinal("sexo")),
                            email = lector.IsDBNull(lector.GetOrdinal("email")) ? default(string) : lector.GetString(lector.GetOrdinal("email")),
                            celular = lector.IsDBNull(lector.GetOrdinal("celular")) ? default(string) : lector.GetString(lector.GetOrdinal("celular")),
                            estado = lector.IsDBNull(lector.GetOrdinal("estado")) ? default(string) : lector.GetString(lector.GetOrdinal("estado")),
                            //Cantidad = lector.IsDBNull(lector.GetOrdinal("Cantidad")) ? default(int) : lector.GetInt32(lector.GetOrdinal("Cantidad")),
                            UsuarioCreacion = lector.IsDBNull(lector.GetOrdinal("usuario_registro")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario_registro")),
                            FechaCreacion = lector.IsDBNull(lector.GetOrdinal("fecha_registro")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("fecha_registro")),
                            UsuarioModificacion = lector.IsDBNull(lector.GetOrdinal("usuario_modifica")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario_modifica")),
                            FechaModificacion = lector.IsDBNull(lector.GetOrdinal("fecha_modifica")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("fecha_modifica"))
                        });
                    }
                }
            }

            return usuarios;
        }

        public IList<SEG_USUARIO> GetAllActives()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
