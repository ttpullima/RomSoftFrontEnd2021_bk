using Microsoft.Practices.EnterpriseLibrary.Data;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Core;
using Romsoft.GESTIONCLINICA.DataAccess.Interfaces.ICVN_TARIFARIO_SEGUS_PARTICIPANTERepository;
using Romsoft.GESTIONCLINICA.Entidades.CVN_TARIFARIO_SEGUS_PARTICIPANTE;
using System;
using System.Collections.Generic;
using System.Data;

namespace Romsoft.GESTIONCLINICA.DataAccess.Tablas
{
    public class CVN_TARIFARIO_SEGUS_PARTICIPANTERepository : Singleton<CVN_TARIFARIO_SEGUS_PARTICIPANTERepository>, ICVN_TARIFARIO_SEGUS_PARTICIPANTERepository<CVN_TARIFARIO_SEGUS_PARTICIPANTE>
    {
        #region Attributos

        private readonly Database _database = new DatabaseProviderFactory().Create(ConectionStringRepository.ConnectionStringNameSQL);


        #endregion

        public int Add(CVN_TARIFARIO_SEGUS_PARTICIPANTE entity)
        {
            int id;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_TARIFARIO_SEGUS_PARTICIPANTE_Insert")))
            {
                _database.AddInParameter(comando, "@id_tarifario_segus", DbType.Int32, entity.id_tarifario_segus);
                _database.AddInParameter(comando, "@id_tarifario_segus_referencia", DbType.Int32, entity.id_tarifario_segus_referencia);
                _database.AddInParameter(comando, "@id_user_registro", DbType.Int32, entity.id_usuarioCreacion);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                id = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return id;
        }

        public int Delete(CVN_TARIFARIO_SEGUS_PARTICIPANTE entity)
        {
            int id;

            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_TARIFARIO_SEGUS_PARTICIPANTE_Delete")))
            {
                _database.AddInParameter(comando, "@id_tarifario_segus_participante", DbType.String, entity.id_tarifario_segus_participante);
                _database.AddOutParameter(comando, "@Response", DbType.Int32, 11);

                _database.ExecuteNonQuery(comando);
                id = Convert.ToInt32(_database.GetParameterValue(comando, "@Response"));
            }

            return id;
        }

        public bool Exists(CVN_TARIFARIO_SEGUS_PARTICIPANTE entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TARIFARIO_SEGUS_PARTICIPANTE> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TARIFARIO_SEGUS_PARTICIPANTE> GetAllActives()
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TARIFARIO_SEGUS_PARTICIPANTE> GetAllActivesFilters(CVN_TARIFARIO_SEGUS_PARTICIPANTE entity)
        {
            List<CVN_TARIFARIO_SEGUS_PARTICIPANTE> tarifario_segus = new List<CVN_TARIFARIO_SEGUS_PARTICIPANTE>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_CVN_TARIFARIO_SEGUS_PARTICIPANTE_GetAllActives")))
            {
                _database.AddInParameter(comando, "@id_tarifario_segus", DbType.Int32, entity.id_tarifario_segus);

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        tarifario_segus.Add(new CVN_TARIFARIO_SEGUS_PARTICIPANTE
                        {
                            id_tarifario_segus_participante = lector.IsDBNull(lector.GetOrdinal("id_tarifario_segus_participante")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_tarifario_segus_participante")),
                            id_tarifario_segus_referencia = lector.IsDBNull(lector.GetOrdinal("id_tarifario_segus_referencia")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_tarifario_segus_referencia")),
                            id_tarifario_segus = lector.IsDBNull(lector.GetOrdinal("id_tarifario_segus")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_tarifario_segus")),
                            c_codigo = lector.IsDBNull(lector.GetOrdinal("c_codigo")) ? default(string) : lector.GetString(lector.GetOrdinal("c_codigo")),
                            t_descripcion_esp = lector.IsDBNull(lector.GetOrdinal("t_descripcion_esp")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion_esp")),

                        });
                    }
                }
            }

            return tarifario_segus;
        }

        public IList<CVN_TARIFARIO_SEGUS_PARTICIPANTE> GetAllFilters(CVN_TARIFARIO_SEGUS_PARTICIPANTE entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TARIFARIO_SEGUS_PARTICIPANTE> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public CVN_TARIFARIO_SEGUS_PARTICIPANTE GetByEstado(string estadoNombre)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TARIFARIO_SEGUS_PARTICIPANTE> GetById(CVN_TARIFARIO_SEGUS_PARTICIPANTE entity)
        {
            throw new NotImplementedException();
        }

        public int Update(CVN_TARIFARIO_SEGUS_PARTICIPANTE entity)
        {
            throw new NotImplementedException();
        }
    }
}
