using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_TARIFARIO_SEGUS
{
    public class CVN_TARIFARIO_LISTADTO
    {
        public int id_tarifario_segus { get; set; }
        public string  c_codigo { get; set; }
        public string c_codigo_susalud { get; set; }
        public string  t_descripcion_esp { get; set; }
        public string  t_descripcion_eng { get; set; }
        public string t_observacion { get; set; }
        public string t_clasificacion { get; set; }
        public string estado { get; set; }
    }
}
