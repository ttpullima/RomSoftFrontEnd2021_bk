using Romsoft.GESTIONCLINICA.Entidades.Core;
using System;

namespace Romsoft.GESTIONCLINICA.Entidades.CVN_MONEDA
{
    public class CVN_MONEDA : EntityAuditable
    {
        public int id_moneda { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }

    }
}
