using Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ICVN_TARIFARIO_SEGUSBL;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CVN_TARIFARIO_SEGUS;
using System;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Tablas
{
    public class CVN_TARIFARIO_SEGUSBL : Singleton<CVN_TARIFARIO_SEGUSBL>, ICVN_TARIFARIO_SEGUSBL<CVN_TARIFARIO_SEGUS>
    {
        public int Add(CVN_TARIFARIO_SEGUS entity)
        {
            return CVN_TARIFARIO_SEGUSRepository.Instancia.Add(entity);
        }

        public int Delete(CVN_TARIFARIO_SEGUS entity)
        {
            return CVN_TARIFARIO_SEGUSRepository.Instancia.Delete(entity);
        }

        public bool Exists(CVN_TARIFARIO_SEGUS entity)
        {
            return CVN_TARIFARIO_SEGUSRepository.Instancia.Exists(entity);
        }

        public IList<CVN_TARIFARIO_SEGUS> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TARIFARIO_SEGUS> GetAllActives()
        {
            return CVN_TARIFARIO_SEGUSRepository.Instancia.GetAllActives();
        }

        public IList<CVN_TARIFARIO_SEGUS> GetAllFilters(CVN_TARIFARIO_SEGUS entity)
        {
            return CVN_TARIFARIO_SEGUSRepository.Instancia.GetAllFilters(entity);
        }

        public IList<CVN_TARIFARIO_SEGUS> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TARIFARIO_SEGUS> GetById(CVN_TARIFARIO_SEGUS entity)
        {
            return CVN_TARIFARIO_SEGUSRepository.Instancia.GetById(entity);
        }

        public int Update(CVN_TARIFARIO_SEGUS entity)
        {
            return CVN_TARIFARIO_SEGUSRepository.Instancia.Update(entity);
        }
    }
}
