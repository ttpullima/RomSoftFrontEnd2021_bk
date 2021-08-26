using Romsoft.GESTIONCLINICA.Entidades.Core;
using System;

namespace Romsoft.GESTIONCLINICA.Entidades.CVN_BENEFICIO
{
    public class CVN_BENEFICIO : EntityAuditable
    {
        public int id_beneficio { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }
    }
}
