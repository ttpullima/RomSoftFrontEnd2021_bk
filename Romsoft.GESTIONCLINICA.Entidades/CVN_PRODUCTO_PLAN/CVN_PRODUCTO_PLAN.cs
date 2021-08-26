using Romsoft.GESTIONCLINICA.Entidades.Core;
using System;

namespace Romsoft.GESTIONCLINICA.Entidades.CVN_PRODUCTO_PLAN
{
    public class CVN_PRODUCTO_PLAN : EntityAuditable
    {
        public int id_producto_plan { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }
        public string c_codigo_iafa { get; set; }
    }
}
