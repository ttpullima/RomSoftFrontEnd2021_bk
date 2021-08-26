using Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ICVN_TARIFARIO_SEGUS_PARTICIPANTEBL;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CVN_TARIFARIO_SEGUS_PARTICIPANTE;
using System;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Tablas
{
    public class CVN_TARIFARIO_SEGUS_PARTICIPANTEBL : Singleton<CVN_TARIFARIO_SEGUS_PARTICIPANTEBL>, ICVN_TARIFARIO_SEGUS_PARTICIPANTEBL<CVN_TARIFARIO_SEGUS_PARTICIPANTE>
    {
        public int Add(CVN_TARIFARIO_SEGUS_PARTICIPANTE entity)
        {
            return CVN_TARIFARIO_SEGUS_PARTICIPANTERepository.Instancia.Add(entity);
        }

        public int Delete(CVN_TARIFARIO_SEGUS_PARTICIPANTE entity)
        {
            return CVN_TARIFARIO_SEGUS_PARTICIPANTERepository.Instancia.Delete(entity);
        }

        public bool Exists(CVN_TARIFARIO_SEGUS_PARTICIPANTE entity)
        {
            //throw new NotImplementedException();
            return false;
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
            return CVN_TARIFARIO_SEGUS_PARTICIPANTERepository.Instancia.GetAllActivesFilters(entity);
        }

        public IList<CVN_TARIFARIO_SEGUS_PARTICIPANTE> GetAllFilters(CVN_TARIFARIO_SEGUS_PARTICIPANTE entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TARIFARIO_SEGUS_PARTICIPANTE> GetAllPaging(PaginationParameter paginationParameters)
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
