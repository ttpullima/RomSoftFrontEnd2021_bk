using Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ICVN_CATEGORIA_PAGO_PRECIOBL;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CVN_CATEGORIA_PAGO_PRECIO;
using System;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Tablas
{
    public class CVN_CATEGORIA_PAGO_PRECIOBL : Singleton<CVN_CATEGORIA_PAGO_PRECIOBL>, ICVN_CATEGORIA_PAGO_PRECIOBL<CVN_CATEGORIA_PAGO_PRECIO>
    {
        public int Add(CVN_CATEGORIA_PAGO_PRECIO entity)
        {
            return CVN_CATEGORIA_PAGO_PRECIORepository.Instancia.Add(entity);
        }

        public int Delete(CVN_CATEGORIA_PAGO_PRECIO entity)
        {
            return CVN_CATEGORIA_PAGO_PRECIORepository.Instancia.Delete(entity);
        }

        public bool Exists(CVN_CATEGORIA_PAGO_PRECIO entity)
        {
            //throw new NotImplementedException();
            return false;
        }

        public IList<CVN_CATEGORIA_PAGO_PRECIO> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CATEGORIA_PAGO_PRECIO> GetAllActives()
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CATEGORIA_PAGO_PRECIO> GetAllActivesFilters(CVN_CATEGORIA_PAGO_PRECIO entity)
        {
            return CVN_CATEGORIA_PAGO_PRECIORepository.Instancia.GetAllActivesFilters(entity);
        }

        public IList<CVN_CATEGORIA_PAGO_PRECIO> GetAllFilters(CVN_CATEGORIA_PAGO_PRECIO entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CATEGORIA_PAGO_PRECIO> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CATEGORIA_PAGO_PRECIO> GetById(CVN_CATEGORIA_PAGO_PRECIO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(CVN_CATEGORIA_PAGO_PRECIO entity)
        {
            throw new NotImplementedException();
        }
    }
}
