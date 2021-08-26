using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.FAC_DOCUMENTO_PAGO
{
    public class FAC_COMPROBANTEReqDTO
    {
		public int id_documento_pago { get; set; }
		public int id_atencion { get; set; }
		public int id_tipo_documento { get; set; }
		public string c_numero_de_documento { get; set; }
		public string t_direccion { get; set; }
		public string t_paciente { get; set; }
		public DateTime d_fecha_emis { get; set; }
		public int id_condicion_pago { get; set; }
		public int id_moneda { get; set; }
		public int n_porcen_igv { get; set; }
		public int n_porcen_descu { get; set; }
		public decimal n_total_bruto { get; set; }
		public decimal n_total_descuento { get; set; }
		public decimal n_total_anticipo { get; set; }
		public decimal n_total_gravada { get; set; }
		public decimal n_total_no_gravada { get; set; }
		public decimal n_total_icbper { get; set; }
		public decimal n_total_impuesto { get; set; }
		public decimal n_total_neto { get; set; }
		public string t_observacion { get; set; }
		public int id_user_registro { get; set; }
		
		public List<FAC_COMPROBANTE_DetalleDTO> DetalleComprobante { get; set; }

		//public int Response { get; set; }
		//public string Response_t { get; set; }
	}
}
