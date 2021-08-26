using Romsoft.GESTIONCLINICA.DTO.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_TARIFARIO_SEGUS
{
    public class CVN_TARIFARIO_SEGUSDTO : EntityAuditableDTO
    {
        public int id_tarifario_segus { get; set; }
        public string c_codigo { get; set; }
        public string c_codigo_susalud { get; set; }
        public string t_descripcion_esp { get; set; }
        public string t_descripcion_eng { get; set; }
        public string t_observacion { get; set; }
        public int id_clasificacion_segus { get; set; }
        public int id_clasificacion_susalud { get; set; }
        public int id_clasificacion_susalud_od { get; set; }
        public int id_centro_costo { get; set; }
        public int id_cuenta_contable { get; set; }
        public int id_tipo_precio { get; set; }
        public decimal n_unidad { get; set; }
        public int n_ayudante { get; set; }
        public int n_instrumentista { get; set; }
        public int n_dias { get; set; }
        public decimal n_porcentaje { get; set; }
        public int f_estado { get; set; }

        //response
        public string estado { get; set; }
        public int Id_estado { get; set; }
        public string t_clasificacion { get; set; }
        // para filtror data
        public string valorRequest { get; set; }
    }
}
