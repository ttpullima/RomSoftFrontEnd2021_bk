using Romsoft.GESTIONCLINICA.Entidades.Core;
using System;

namespace Romsoft.GESTIONCLINICA.Entidades.ADM_ESTADO_CIVIL
{
    public class ADM_ESTADO_CIVIL : EntityAuditable
    {
        public int id_estado_civil { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }
    }
}
