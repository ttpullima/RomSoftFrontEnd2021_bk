using System;
using System.Collections.Generic;
using Romsoft.GESTIONCLINICA.Entidades.Core;

namespace Romsoft.GESTIONCLINICA.Entidades.ADM_OCUPACION
{
    public class ADM_OCUPACION : EntityAuditable
    {
        public int id_ocupacion { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }
        public string t_observacion { get; set; }
        public Nullable<int> f_estado { get; set; }
        public string estado { get; set; }
    }
}
