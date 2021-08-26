using Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ICON_CUENTA_CONTABLEBL;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CON_CUENTA_CONTABLE;
using System;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Tablas
{
    public class CON_CUENTA_CONTABLEBL : Singleton<CON_CUENTA_CONTABLEBL>, ICON_CUENTA_CONTABLEBL<CON_CUENTA_CONTABLE>
    {
        public int Add(CON_CUENTA_CONTABLE entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(CON_CUENTA_CONTABLE entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(CON_CUENTA_CONTABLE entity)
        {
            throw new NotImplementedException();
        }

        public IList<CON_CUENTA_CONTABLE> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CON_CUENTA_CONTABLE> GetAllActives()
        {
            return CON_CUENTA_CONTABLERepository.Instancia.GetAllActives();
        }

        public IList<CON_CUENTA_CONTABLE> GetAllFilters(CON_CUENTA_CONTABLE entity)
        {
            throw new NotImplementedException();
        }

        public IList<CON_CUENTA_CONTABLE> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public CON_CUENTA_CONTABLE GetByEstado(string rolNombre)
        {
            throw new NotImplementedException();
        }

        public IList<CON_CUENTA_CONTABLE> GetById(CON_CUENTA_CONTABLE entity)
        {
            throw new NotImplementedException();
        }

        public int Update(CON_CUENTA_CONTABLE entity)
        {
            throw new NotImplementedException();
        }
    }
}
