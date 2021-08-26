using System;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_DOCUMENTO_AUTORIZACION
{
    public class ADM_DOCUMENTO_AUTORIZACION_RESDTO
    {
        public int id_documento_autorizacion { get; set; }

        public int id_plan_seguro { get; set; }

        public int id_categoria_pago { get; set; }

        public string codigo_asegurado { get; set; }

        public string numero_contrato { get; set; }
        public int id_beneficio { get; set; }

        public int id_atecion_autoriza { get; set; }
        public string c_cod_autorizacion { get; set; }

        public DateTime d_fecha_autorizacion { get; set; }

        public int id_tipo_filiacion { get; set; }

        public string t_nombre_titular { get; set; }

        public int id_tipo_afiliacion { get; set; }

        public int id_moneda { get; set; }

        public double c_num_copago_fijo { get; set; }

        public double c_num_copago_variable { get; set; }

        public int id_producto_plan { get; set; }
    }
}
