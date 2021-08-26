using Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.IADM_OCUPACIONBL;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.ADM_OCUPACION;
using System;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Tablas
{
    public class ADM_OCUPACIONBL : Singleton<ADM_OCUPACIONBL>, IADM_OCUPACIONBL<ADM_OCUPACION>
    {
        public int Add(ADM_OCUPACION entity)
        {
            return ADM_OCUPACION_Repository.Instancia.Add(entity);
        }

        public int Delete(ADM_OCUPACION entity)
        {
            return ADM_OCUPACION_Repository.Instancia.Delete(entity);
        }

        public bool Exists(ADM_OCUPACION entity)
        {
            return ADM_OCUPACION_Repository.Instancia.Exists(entity);
        }

        public IList<ADM_OCUPACION> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<ADM_OCUPACION> GetAllFilters(ADM_OCUPACION entity)
        {
            return ADM_OCUPACION_Repository.Instancia.GetAllFilters(entity);
        }

        public IList<ADM_OCUPACION> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public IList<ADM_OCUPACION> GetById(ADM_OCUPACION entity)
        {
            return ADM_OCUPACION_Repository.Instancia.GetById(entity);
        }

        public int Update(ADM_OCUPACION entity)
        {
            return ADM_OCUPACION_Repository.Instancia.Update(entity);
        }

        public IList<ADM_OCUPACION> GetAllActives()
        {
            return ADM_OCUPACION_Repository.Instancia.GetAllActives();
        }

    }
}
