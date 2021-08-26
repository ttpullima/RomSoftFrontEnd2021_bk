using Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ICVN_CATEGORIA_PAGOBL;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CVN_CATEGORIA_PAGO;
using System;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Tablas
{
    public class CVN_CATEGORIA_PAGOBL : Singleton<CVN_CATEGORIA_PAGOBL>, ICVN_CATEGORIA_PAGOBL<CVN_CATEGORIA_PAGO>
    {
        public int Add(CVN_CATEGORIA_PAGO entity)
        {
            return CVN_CATEGORIA_PAGORepository.Instancia.Add(entity);
        }

        public int Delete(CVN_CATEGORIA_PAGO entity)
        {
            return CVN_CATEGORIA_PAGORepository.Instancia.Delete(entity);
        }

        public bool Exists(CVN_CATEGORIA_PAGO entity)
        {
            return CVN_CATEGORIA_PAGORepository.Instancia.Exists(entity);
        }

        public IList<CVN_CATEGORIA_PAGO> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CATEGORIA_PAGO> GetAllActives()
        {
            return CVN_CATEGORIA_PAGORepository.Instancia.GetAllActives();
        }

        public IList<CVN_CATEGORIA_PAGO> GetAllFilters(CVN_CATEGORIA_PAGO entity)
        {
            return CVN_CATEGORIA_PAGORepository.Instancia.GetAllFilters(entity);
        }

        public IList<CVN_CATEGORIA_PAGO> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public CVN_CATEGORIA_PAGO GetByEstado(string rolNombre)
        {
            throw new NotImplementedException();
        }

        public IList<CVN_CATEGORIA_PAGO> GetById(CVN_CATEGORIA_PAGO entity)
        {
            return CVN_CATEGORIA_PAGORepository.Instancia.GetById(entity);
        }

        public int Update(CVN_CATEGORIA_PAGO entity)
        {
            return CVN_CATEGORIA_PAGORepository.Instancia.Update(entity);
        }
    }
}
