using Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.CVN_CLASIFICACION_SUSALUDBL;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CVN_CLASIFICACION_SUSALUD;
using System;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Tablas
{
    public class CVN_CLASIFICACION_SUSALUDBL : Singleton<CVN_CLASIFICACION_SUSALUDBL>, ICVN_CLASIFICACION_SUSALUDBL<CVN_CLASIFICACION_SUSALUD>
    {
        public int Add(CVN_CLASIFICACION_SUSALUD entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(CVN_CLASIFICACION_SUSALUD entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(CVN_CLASIFICACION_SUSALUD entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SUSALUD> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SUSALUD> GetAllActives()
        {
            return CVN_CLASIFICACION_SUSALUDRepository.Instancia.GetAllActives();
        }

        public IList<CVN_CLASIFICACION_SUSALUD> GetAllFilters(CVN_CLASIFICACION_SUSALUD entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SUSALUD> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public CVN_CLASIFICACION_SUSALUD GetByEstado(string rolNombre)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SUSALUD> GetById(CVN_CLASIFICACION_SUSALUD entity)
        {
            throw new NotImplementedException();
        }

        public int Update(CVN_CLASIFICACION_SUSALUD entity)
        {
            throw new NotImplementedException();
        }
    }
}
