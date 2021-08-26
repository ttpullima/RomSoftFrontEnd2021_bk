using Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.ISEG_USUARIO;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.SEG_USUARIO;
using System;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Tablas
{


    public class SEG_USUARIOBL : Singleton<SEG_USUARIOBL>, ISEG_USUARIOBL<SEG_USUARIO>
    {
        public int Add(SEG_USUARIO entity)
        {
            return SEG_USUARIORepository.Instancia.Add(entity);
        }

        public int Delete(SEG_USUARIO entity)
        {
            return SEG_USUARIORepository.Instancia.Delete(entity);
        }

        public bool Exists(SEG_USUARIO entity)
        {
            return SEG_USUARIORepository.Instancia.Exists(entity);
        }

        public IList<SEG_USUARIO> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<SEG_USUARIO> GetAllActives()
        {
            throw new NotImplementedException();
        }

        public IList<SEG_USUARIO> GetAllFilters(SEG_USUARIO entity)
        {
            return SEG_USUARIORepository.Instancia.GetAllFilters(entity);
        }

        public IList<SEG_USUARIO> GetAllPaging(PaginationParameter paginationParameters)
        {
            return SEG_USUARIORepository.Instancia.GetAllPaging(paginationParameters);
        }

        public IList<SEG_USUARIO> GetById(SEG_USUARIO entity)
        {
            return SEG_USUARIORepository.Instancia.GetById(entity);
        }

        public SEG_USUARIO GetByUsername(string username,string clave)
        {
            return SEG_USUARIORepository.Instancia.GetByUsername(username, clave);
        }

        public int Update(SEG_USUARIO entity)
        {
            return SEG_USUARIORepository.Instancia.Update(entity);
        }
    }
}
