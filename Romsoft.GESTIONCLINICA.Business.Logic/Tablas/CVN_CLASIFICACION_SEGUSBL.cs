using Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.CVN_CLASIFICACION_SEGUSBL;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CVN_CLASIFICACION_SEGUS;
using System;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Tablas
{
    public class CVN_CLASIFICACION_SEGUSBL : Singleton<CVN_CLASIFICACION_SEGUSBL>, ICVN_CLASIFICACION_SEGUSBL<CVN_CLASIFICACION_SEGUS>
    {
        public int Add(CVN_CLASIFICACION_SEGUS entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(CVN_CLASIFICACION_SEGUS entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(CVN_CLASIFICACION_SEGUS entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SEGUS> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SEGUS> GetAllActives()
        {
            return CVN_CLASIFICACION_SEGUSRepository.Instancia.GetAllActives();
        }


        public IList<CVN_CLASIFICACION_SEGUS> GetAllFilters(CVN_CLASIFICACION_SEGUS entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SEGUS> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public CVN_CLASIFICACION_SEGUS GetByEstado(string rolNombre)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SEGUS> GetById(CVN_CLASIFICACION_SEGUS entity)
        {
            throw new NotImplementedException();
        }

        public int Update(CVN_CLASIFICACION_SEGUS entity)
        {
            throw new NotImplementedException();
        }
    }
}
