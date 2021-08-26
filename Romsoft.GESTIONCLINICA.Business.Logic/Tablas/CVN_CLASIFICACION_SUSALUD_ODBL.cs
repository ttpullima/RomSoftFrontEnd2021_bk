using Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ICVN_CLASIFICACION_SUSALUD_ODBL;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CVN_CLASIFICACION_SUSALUD_OD;
using System;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Tablas
{
    public class CVN_CLASIFICACION_SUSALUD_ODBL : Singleton<CVN_CLASIFICACION_SUSALUD_ODBL>, ICVN_CLASIFICACION_SUSALUD_ODBL<CVN_CLASIFICACION_SUSALUD_OD>
    {
        public int Add(CVN_CLASIFICACION_SUSALUD_OD entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(CVN_CLASIFICACION_SUSALUD_OD entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(CVN_CLASIFICACION_SUSALUD_OD entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SUSALUD_OD> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SUSALUD_OD> GetAllActives()
        {
            return CVN_CLASIFICACION_SUSALUD_ODRepository.Instancia.GetAllActives();
        }

        public IList<CVN_CLASIFICACION_SUSALUD_OD> GetAllFilters(CVN_CLASIFICACION_SUSALUD_OD entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SUSALUD_OD> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public CVN_CLASIFICACION_SUSALUD_OD GetByEstado(string rolNombre)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CLASIFICACION_SUSALUD_OD> GetById(CVN_CLASIFICACION_SUSALUD_OD entity)
        {
            throw new NotImplementedException();
        }

        public int Update(CVN_CLASIFICACION_SUSALUD_OD entity)
        {
            throw new NotImplementedException();
        }
    }
}
