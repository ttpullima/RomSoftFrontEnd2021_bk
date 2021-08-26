using Microsoft.Practices.EnterpriseLibrary.Data;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Core;
using Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ISEG_ROLRepository;
using Romsoft.GESTIONCLINICA.Entidades.SEG_ROL;
using System;
using System.Collections.Generic;
using System.Data;

namespace Romsoft.GESTIONCLINICA.DataAccess.Tablas
{


    public class SEG_ROLRepository : Singleton<SEG_ROLRepository>, ISEG_ROLRepository<SEG_ROL>
    {
        #region Attributos

        private readonly Database _database = new DatabaseProviderFactory().Create(ConectionStringRepository.ConnectionStringNameSQL);


        #endregion

        #region Métodos Públicos

        public int Add(SEG_ROL entity)
        {
            int id;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_SEG_ROL_Insert")))
            {
                _database.AddInParameter(comando, "@rol", DbType.String, entity.rol);
                _database.AddInParameter(comando, "@descripcion", DbType.String, entity.descripcion);
                _database.AddInParameter(comando, "@estado", DbType.String, entity.estado);
                _database.AddInParameter(comando, "@UsuarioCreacion", DbType.String, entity.UsuarioCreacion);
                _database.AddInParameter(comando, "@fecha_registro", DbType.DateTime, entity.FechaCreacion);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                id = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return id;
        }

        public int Delete(SEG_ROL entity)
        {
            int idResult;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_SEG_ROL_Delete")))
            {
                _database.AddInParameter(comando, "@id_rol", DbType.Int32, entity.id_rol);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                idResult = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return idResult;
        }

        public bool Exists(SEG_ROL entity)
        {
            bool existe = false;
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_SEG_ROL_VerifyExists")))
            {
                _database.AddInParameter(comando, "@rol", DbType.String, entity.rol);

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

        public IList<SEG_ROL> GetAllPaging(PaginationParameter paginationParameters)
        {
            List<SEG_ROL> roles = new List<SEG_ROL>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_SEG_ROL_GetAllFilter")))
            {
                _database.AddInParameter(comando, "@WhereFilters", DbType.String, string.IsNullOrWhiteSpace(paginationParameters.WhereFilter) ? string.Empty : paginationParameters.WhereFilter);
                _database.AddInParameter(comando, "@OrderBy", DbType.String, string.IsNullOrWhiteSpace(paginationParameters.OrderBy) ? string.Empty : paginationParameters.OrderBy);
                _database.AddInParameter(comando, "@Start", DbType.Int32, paginationParameters.Start);
                _database.AddInParameter(comando, "@Rows", DbType.Int32, paginationParameters.AmountRows);

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        roles.Add(new SEG_ROL
                        {
                            
                            id_rol = lector.IsDBNull(lector.GetOrdinal("Id_rol")) ? default(int) : lector.GetInt32(lector.GetOrdinal("Id_rol")),
                            rol = lector.IsDBNull(lector.GetOrdinal("rol")) ? default(string) : lector.GetString(lector.GetOrdinal("rol")),
                            descripcion = lector.IsDBNull(lector.GetOrdinal("Descripcion")) ? default(string) : lector.GetString(lector.GetOrdinal("Descripcion")),
                            estado = lector.IsDBNull(lector.GetOrdinal("Estado")) ? default(string) : lector.GetString(lector.GetOrdinal("Estado")),
                            UsuarioCreacion = lector.IsDBNull(lector.GetOrdinal("usuario_registro")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario_registro")),
                            FechaCreacion = lector.IsDBNull(lector.GetOrdinal("fecha_registro")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("fecha_registro")),
                            UsuarioModificacion = lector.IsDBNull(lector.GetOrdinal("usuario_modifica")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario_modifica")),
                            FechaModificacion = lector.IsDBNull(lector.GetOrdinal("fecha_modifica")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("fecha_modifica"))
                        
                        });
                    }
                }
            }

            return roles;
        }

        public IList<SEG_ROL> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<SEG_ROL> GetById(SEG_ROL entity)
        {
            List<SEG_ROL> roles = new List<SEG_ROL>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_SEG_ROL_GetById")))
            {
                _database.AddInParameter(comando, "@Id_rol", DbType.Int32, entity.id_rol);

                using (var lector = _database.ExecuteReader(comando))
                {
                    if (lector.Read())
                    {
                        roles.Add( new SEG_ROL
                        {
                            id_rol = lector.IsDBNull(lector.GetOrdinal("Id_rol")) ? default(int) : lector.GetInt32(lector.GetOrdinal("Id_rol")),
                            rol = lector.IsDBNull(lector.GetOrdinal("rol")) ? default(string) : lector.GetString(lector.GetOrdinal("rol")),
                            descripcion = lector.IsDBNull(lector.GetOrdinal("Descripcion")) ? default(string) : lector.GetString(lector.GetOrdinal("Descripcion")),
                            estado = lector.IsDBNull(lector.GetOrdinal("Estado")) ? default(string) : lector.GetString(lector.GetOrdinal("Estado")),
                            UsuarioCreacion = lector.IsDBNull(lector.GetOrdinal("usuario_registro")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario_registro")),
                            FechaCreacion = lector.IsDBNull(lector.GetOrdinal("fecha_registro")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("fecha_registro")),
                            UsuarioModificacion = lector.IsDBNull(lector.GetOrdinal("usuario_modifica")) ? default(string) : lector.GetString(lector.GetOrdinal("usuario_modifica")),
                            FechaModificacion = lector.IsDBNull(lector.GetOrdinal("fecha_modifica")) ? default(DateTime) : lector.GetDateTime(lector.GetOrdinal("fecha_modifica"))

                        });
                    }
                }
            }

            return roles;
        }


        public int Update(SEG_ROL entity)
        {
            int id;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_SEG_ROL_Update")))
            {
               
                _database.AddInParameter(comando, "@id_rol", DbType.Int32, entity.id_rol);
                _database.AddInParameter(comando, "@rol", DbType.String, entity.rol);
                _database.AddInParameter(comando, "@descripcion", DbType.String, entity.descripcion);
                _database.AddInParameter(comando, "@estado", DbType.String, entity.estado);
                _database.AddInParameter(comando, "@UsuarioCreacion", DbType.String, entity.UsuarioCreacion);
                _database.AddInParameter(comando, "@fecha_registro", DbType.DateTime, entity.FechaCreacion);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                id = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return id;
        }

        public SEG_ROL GetByRol(string rolNombre)
        {
            throw new NotImplementedException();
        }

        public IList<SEG_ROL> GetAllActives()
        {
            List<SEG_ROL> roles = new List<SEG_ROL>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_SEG_ROL_GetAllActives")))
            {

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        roles.Add(new SEG_ROL
                        {

                            id_rol = lector.IsDBNull(lector.GetOrdinal("Id_rol")) ? default(int) : lector.GetInt32(lector.GetOrdinal("Id_rol")),
                            rol = lector.IsDBNull(lector.GetOrdinal("rol")) ? default(string) : lector.GetString(lector.GetOrdinal("rol")),
                        });
                    }
                }
            }

            return roles;
        }

        public IList<SEG_ROL> GetAllFilters(SEG_ROL entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
