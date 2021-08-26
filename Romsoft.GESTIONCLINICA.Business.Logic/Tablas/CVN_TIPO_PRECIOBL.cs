using Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ICVN_TIPO_PRECIOBL;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CVN_TIPO_PRECIO;
using System;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Tablas
{
    public class CVN_TIPO_PRECIOBL : Singleton<CVN_TIPO_PRECIOBL>, ICVN_TIPO_PRECIOBL<CVN_TIPO_PRECIO>
    {
        public int Add(CVN_TIPO_PRECIO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(CVN_TIPO_PRECIO entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(CVN_TIPO_PRECIO entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TIPO_PRECIO> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TIPO_PRECIO> GetAllActives()
        {
            return CVN_TIPO_PRECIORepository.Instancia.GetAllActives();
        }

        public IList<CVN_TIPO_PRECIO> GetAllFilters(CVN_TIPO_PRECIO entity)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TIPO_PRECIO> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public CVN_TIPO_PRECIO GetByEstado(string rolNombre)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_TIPO_PRECIO> GetById(CVN_TIPO_PRECIO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(CVN_TIPO_PRECIO entity)
        {
            throw new NotImplementedException();
        }
    }
}
