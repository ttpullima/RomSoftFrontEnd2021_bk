using Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ISEG_ROLBL;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.SEG_ROL;
using System;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Tablas
{

    public class SEG_ROLBL : Singleton<SEG_ROLBL>, ISEG_ROLBL<SEG_ROL>
    {
        public int Add(SEG_ROL entity)
        {
            return SEG_ROLRepository.Instancia.Add(entity);
        }

        public int Delete(SEG_ROL entity)
        {
            return SEG_ROLRepository.Instancia.Delete(entity);
        }

        public bool Exists(SEG_ROL entity)
        {
            return SEG_ROLRepository.Instancia.Exists(entity);
        }

        public IList<SEG_ROL> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<SEG_ROL> GetAllActives()
        {
            return SEG_ROLRepository.Instancia.GetAllActives();
        }

        public IList<SEG_ROL> GetAllFilters(SEG_ROL entity)
        {
            throw new NotImplementedException();
        }

        public IList<SEG_ROL> GetAllPaging(PaginationParameter paginationParameters)
        {
            return SEG_ROLRepository.Instancia.GetAllPaging(paginationParameters);
        }

        public IList<SEG_ROL> GetById(SEG_ROL entity)
        {
            return SEG_ROLRepository.Instancia.GetById(entity);
        }

        public SEG_ROL GetByRol(string rolNombre)
        {
            return SEG_ROLRepository.Instancia.GetByRol(rolNombre);
        }

        public int Update(SEG_ROL entity)
        {
            return SEG_ROLRepository.Instancia.Update(entity);
        }
    }

}
