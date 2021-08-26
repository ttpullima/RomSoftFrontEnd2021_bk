using Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ICON_CENTRO_COSTOBL;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CON_CENTRO_COSTO;
using System;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Tablas
{
    public class CON_CENTRO_COSTOBL : Singleton<CON_CENTRO_COSTOBL>, ICON_CENTRO_COSTOBL<CON_CENTRO_COSTO>
    {
        public int Add(CON_CENTRO_COSTO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(CON_CENTRO_COSTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(CON_CENTRO_COSTO entity)
        {
            throw new NotImplementedException();
        }

        public IList<CON_CENTRO_COSTO> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CON_CENTRO_COSTO> GetAllActives()
        {
            return CON_CENTRO_COSTORepository.Instancia.GetAllActives();
        }

        public IList<CON_CENTRO_COSTO> GetAllFilters(CON_CENTRO_COSTO entity)
        {
            throw new NotImplementedException();
        }

        public IList<CON_CENTRO_COSTO> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public CON_CENTRO_COSTO GetByEstado(string rolNombre)
        {
            throw new NotImplementedException();
        }

        public IList<CON_CENTRO_COSTO> GetById(CON_CENTRO_COSTO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(CON_CENTRO_COSTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
