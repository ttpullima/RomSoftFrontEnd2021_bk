using Romsoft.GESTIONCLINICA.Entidades.Core;
using System;

namespace Romsoft.GESTIONCLINICA.Entidades.ADM_UBIGEO
{
    public class ADM_UBIGEO : EntityAuditable
    {
        public int id_ubigeo { get; set; }
        public string c_codigo { get; set; }

        public string t_pais { get; set; }

        public string t_departamento { get; set; }

        public string t_provincia { get; set; }

        public string t_distrito { get; set; }

        //request busqueda
        public string ValorBusqueda { get; set; }
    }
}
