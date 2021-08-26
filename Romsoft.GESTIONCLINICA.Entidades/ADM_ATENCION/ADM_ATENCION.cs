using Romsoft.GESTIONCLINICA.Entidades.Core;
using System;


namespace Romsoft.GESTIONCLINICA.Entidades.ADM_ATENCION
{
    public class ADM_ATENCION : EntityAuditable
    {
        public int id_atencion { get; set; }
        public long id_nro_interno { get; set; }
        public int id_paciente { get; set; }
        public int id_calificacion { get; set; }
        public int id_tipo_paciente { get; set; }
        public int id_tipo_atencion { get; set; }
        public DateTime d_fecha_ingreso { get; set; }
        public string c_hora_ingreso { get; set; }
        public int id_plan_seguro { get; set; }
        public int id_beneficio { get; set; }
        public int id_atencion_autoriza { get; set; }
        public string t_nombre_titular { get; set; }
        public int id_parentesco { get; set; }
        public int id_atencion_diagnostico { get; set; }
        public int id_atencion_cita { get; set; }
        public int id_medico { get; set; }
        public int id_atencion_hospitaliza { get; set; }
        public int id_tipo_egreso { get; set; }
        public DateTime d_fecha_egreso { get; set; }
        public string c_hora_egreso { get; set; }
        public DateTime d_fecha_cierre { get; set; }
        public string c_hora_cierre { get; set; }
        public string t_observacion { get; set; }
        public decimal n_a_no_gravado { get; set; }
        public decimal n_a_gravado { get; set; }
        public decimal n_a_impuesto { get; set; }
        public decimal n_a_total { get; set; }
        public decimal n_p_no_gravado { get; set; }
        public decimal n_p_gravado { get; set; }
        public decimal n_p_impuesto { get; set; }
        public decimal n_p_total { get; set; }
        public decimal n_g_no_gravado { get; set; }
        public decimal n_g_gravado { get; set; }
        public decimal n_g_impuesto { get; set; }
        public decimal n_g_total { get; set; }
        public int n_paciente_derivado { get; set; }
        public int id_cita { get; set; }
        public int id_categoria_pago { get; set; }
        public string c_codigo_asegurado { get; set; }
        public string c_contrato { get; set; }
        public int id_documento_prestacion1 { get; set; }
        public string c_documento_prestacion1 { get; set; }
        public int id_documento_prestacion2 { get; set; }
        public string c_documento_prestacion2 { get; set; }
        public DateTime d_fecha_autorizacion1 { get; set; }
        public DateTime d_fecha_autorizacion2 { get; set; }
        public int id_tipo_filiacion { get; set; }
        public int id_tipo_afiliacion { get; set; }
        public int id_moneda { get; set; }

        public decimal n_copago_fijo { get; set; }
        public decimal n_copago_variable { get; set; }
        public decimal n_copago_variable_far { get; set; }
        public int id_producto_plan { get; set; }
        public decimal n_limite_cobertura { get; set; }
        public int id_tipo_diagnostico { get; set; }
        public int id_diagnostico { get; set; }
        public string c_numero_placa { get; set; }
        public int n_deja_denuncia { get; set; }
        public int n_deja_carta { get; set; }
        public string t_observacion_accidente { get; set; }
        public int id_profesional { get; set; }
        public int id_hospitalizacion { get; set; }
        public string t_observacion_general { get; set; }
        public int id_tipo_facturacion { get; set; }
        public DateTime d_fecha_registro { get; set; }
        public string c_hora_registro { get; set; }
        public int f_estado { get; set; }

        //Request
        public DateTime d_fecha_registro_1 { get; set; }
        public DateTime d_fecha_registro_2 { get; set; }
        //Response
        public string tipo_paciente { get; set; }
        public string tipo_atencion { get; set; }
        public string garante { get; set; }
        public string contratante { get; set; }
        public string estado { get; set; }
    }
}
