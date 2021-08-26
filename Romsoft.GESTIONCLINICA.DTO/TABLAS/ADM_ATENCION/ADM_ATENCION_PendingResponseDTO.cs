using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_ATENCION
{
    public class ADM_ATENCION_PendingResponseDTO
    {
        public int id_moneda { get; set; }
        public decimal n_copago_fijo { get; set; }
        public int id_documento_pago { get; set; }
        public int id_forma_pago { get; set; }
        public int id_documento_identidad { get; set; }
        public string c_documento_identidad { set; get; }
        public string t_adquiriente { get; set; }
        public string t_direccion { get; set; }
        public string t_paciente { get; set; }
        public int id_tipo_atencion { get; set; }
        public int n_historia_clinica { get; set; }
        public int id_atencion { get; set; }
        public DateTime d_fecha_registro { get; set; }
        public int id_clasificacion_segus { get; set; }
        public string t_clasificacion_segus { get; set; }
        public int id_tarifario_segus { get; set; }
        public string c_codigo_segus { get; set; }
        public string t_descripcion_segus { get; set; }
        public decimal n_precio { get; set; }
        public decimal n_cantidad { get; set; }
        public decimal n_subtotal { get; set; }
        public decimal n_descuento { get; set; }
        public decimal n_total { get; set; }
        public int id_profesional { get; set; }
        public int id_naciones_unidas { get; set; }
        public decimal n_anticipo { get; set; }
        public decimal n_gravado { get; set; }
        public decimal n_no_grabado { get; set; }
        public decimal n_impuesto { get; set; }
        public decimal total { get; set; }
    }
}
