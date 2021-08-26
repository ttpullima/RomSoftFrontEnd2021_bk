using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_ATENCION
{
    public class ADM_ATENCION_PendingRequest
    {
        public int id_atencion { get; set; }
        public string c_tipo_pendiente { get; set; }
        public string c_tipo_facturacion { get; set; }
        public string c_idioma { get; set; }
        public int id_usuario { get; set; }
    }
}
