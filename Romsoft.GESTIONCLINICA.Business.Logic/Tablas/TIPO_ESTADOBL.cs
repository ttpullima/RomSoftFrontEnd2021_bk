using Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ITIPO_ESTADOBL;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.TIPO_ESTADO;
using System;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Tablas
{
    public class TIPO_ESTADOBL : Singleton<TIPO_ESTADOBL>, ITIPO_ESTADOBL<TIPO_ESTADO>
    {
        public int Add(TIPO_ESTADO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(TIPO_ESTADO entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(TIPO_ESTADO entity)
        {
            throw new NotImplementedException();
        }

        public IList<TIPO_ESTADO> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<TIPO_ESTADO> GetAllActives()
        {
            throw new NotImplementedException();
        }

        public IList<TIPO_ESTADO> GetAllFilters(TIPO_ESTADO entity)
        {
            return TIPO_ESTADORepository.Instancia.GetAllFilters(entity);
        }

        public IList<TIPO_ESTADO> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public TIPO_ESTADO GetByEstado(string rolNombre)
        {
            throw new NotImplementedException();
        }

        public IList<TIPO_ESTADO> GetById(TIPO_ESTADO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(TIPO_ESTADO entity)
        {
            throw new NotImplementedException();
        }
    }
}
