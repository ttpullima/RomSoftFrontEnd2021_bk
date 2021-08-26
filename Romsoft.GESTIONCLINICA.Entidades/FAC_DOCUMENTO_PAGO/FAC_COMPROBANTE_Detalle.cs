using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romsoft.GESTIONCLINICA.Entidades.FAC_DOCUMENTO_PAGO
{
    public class FAC_COMPROBANTE_Detalle
    {
        public int id_tarifario_segus { get; set; }
        public string t_tarifario_segus { get; set; }
        public string c_codigo_segus { get; set; }
        public int id_clasificacion_segus { get; set; }
        public string t_clasificacion_segus { get; set; }
        public decimal n_precio { get; set; }
        public decimal n_cantidad { get; set; }
        public decimal n_subtotal { get; set; }
        public decimal n_descuento { get; set; }
        public decimal n_total { get; set; }
    }
}
