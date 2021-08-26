using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romsoft.GESTIONCLINICA.Presentacion.Core
{
    public class ComunFilter
    {
        // Para realizar fitros
        //-- Usuarios
        public static int f_usuario_IdTipoUsers { get; set; }
        public static string f_usuario_LoginName { get; set; }      //Correo
        public static string f_usuario_Apellidos { get; set; }
        public static string f_usuario_Estado { get; set; }
        public static string f_usuario_DNI { get; set; }


        //-- Ocupación
        public static int ocupacion_id { get; set; }
        public static string ocupacion_c_codigo { get; set; }
        public static string ocupacion_t_descripcion { get; set; }
	    public static int ocupacion_f_estado { get; set; }

        //.. Filtro Lista Tarida
        public static string ValorRequest { get; set; }

        //-- Id Seguros
        public static int f_id_tarifario_segus { get; set; }
        //-- Filtro Participantes Tarifario
        public static int id_tarifario_segus_participante { get; set; }
        public static string codParticipante { get; set; }
        public static string nomParticipante { get; set; }
        public static int id_tarifario_segus { get; set; }
        //--Filtro Tarifario
        public static int id_categoria_pago_precio { get; set; }

        public static int cp_id_tarifario_segus { get; set; } //-- Padre de la tabla CVN_TARIFARIO_SEGUS
        public static int cp_id_categoria_pago { get; set; }
        public static string cp_c_codigo { get; set; }
        public static string cp_t_descripcion { get; set; }
        public static decimal cp_n_precio_sol { get; set; }
        public static decimal cp_n_precio_usd { get; set; }
        //Ctategoria Papgo

        //plan de seguro
        public static int ps_id_plan_seguro { get; set; }

        //DetallePlan Seguro
        public static int ps_id_plan_seguro_detalle { get; set; }
        public static string ps_codigo { get; set; }
        public static string ps_beneficio { get; set; }
        public static string ps_moneda { get; set; }
        public static decimal ps_copago_fijo { get; set; }
        public static decimal ps_copago_variable { get; set; }
        public static decimal ps_copago_farmacia { get; set; }

        // CONTACTO
        public static int cp_id_contacto { get; set; }
        //Profesion
        public static int profesional_id { get; set; }
        // paciente
        public static int f_id_paciente { get; set; }
        public static int f_NumHistoriaClinica { get; set; }

        //datos Ubigeo
        public static int f_tipoUbigeo { get; set; }
        public static int f_idUbigeoNacimiento { get; set; }
        public static string f_descripcionUbigeo { get; set; }
        public static int f_idUbigeoDomicilio { get; set; }
        public static string f_descripcionDomicilio { get; set; }

        //atenciones
        public static int f_idAtencion { get; set; }
        public static string f_tipo_pendiente { get; set; }
        public static string f_tipo_facturacion { get; set; }
        public static string f_idioma { get; set; }
        

        // Siteds Req
        public static string sit_origenConsulta { get; set; }  //origen  de ventana consulta atencion/HistoriaClinica
        public static string sit_COD_DOCUMENTO { get; set; }
        public static string sit_COD_AUTORIZACION { get; set; }
        public static string sit_COD_ASEGURADO { get; set; }
        public static DateTime sit_FEC_AUTORIZACION { get; set; }
        public static DateTime sit_FEC_NACIMIENTO { get; set; }
        public static string sit_NOMBRES { get; set; }
        public static string sit_AP_PATERNO { get; set; }
        public static string sit_AP_MATERNO { get; set; }
        public static string sit_PACIENTE { get; set; }
        public static string sit_TITULAR { get; set; }
        public static string sit_RUC_IPRESS { get; set; }
        public static string sit_COD_IAFA { get; set; }
        public static decimal sit_NUM_COPAGO_FIJO { get; set; }
        public static decimal sit_NUM_COPAGO_VARIABLE { get; set; }
        public static string sit_COD_IPRESS { get; set; }
        public static string sit_SEXO { get; set; }
        public static string sit_NUM_DOCUMENTO { get; set; }
        public static string sit_NUM_EDAD { get; set; }
        public static string sit_COD_ASEGURADO_TITULAR { get; set; }
        public static string sit_COD_DOCUMENTO_TITULAR { get; set; }
        public static string sit_NUM_DOCUMENTO_TITULAR { get; set; }
        public static string sit_COD_TIPO_FILIACION { get; set; }
        public static string sit_DES_TIPO_FILIACION { get; set; }
        public static string sit_COD_COBERTURA { get; set; }
        public static string sit_COD_SUBCOBERTURA { get; set; }
        public static string sit_DES_BENEFICIO { get; set; }
        public static string sit_COD_PRODUCTO { get; set; }
        public static string sit_DES_PRODUCTO { get; set; }
        public static string sit_COD_TIPOPLAN { get; set; }
        public static string sit_DES_TIPOPLAN { get; set; }
        public static string sit_COD_TIPO_AFILIACION { get; set; }
        public static string sit_DES_TIPO_AFILIACION { get; set; }
        public static string sit_NUM_POLIZA { get; set; }
        public static string sit_NUM_PLAN { get; set; }
        public static string sit_COD_CONTRATANTE { get; set; }
        public static string sit_COD_CONTRATANTE_ABR { get; set; }
        public static string sit_NUM_CONTRATANTE { get; set; }
        public static string sit_DES_CONTRATANTE { get; set; }
        public static DateTime sit_FEC_INICIO_VIGENCIA { get; set; }
        public static DateTime sit_FEC_FIN_VIGENCIA { get; set; }
        public static DateTime sit_FE_INCLDATE { get; set; }
        public static string sit_COD_MONEDA { get; set; }
        public static string sit_COD_SERVICIO { get; set; }
        public static string sit_NUM_IP { get; set; }

        // Siteds Res
        public static int sit_res_id_documento_autorizacion { get; set; }
        public static int sit_res_id_plan_seguro { get; set; }
        public static int sit_res_id_categoria_pago { get; set; }
        public static string sit_res_codigo_asegurado { get; set; }
        public static string sit_res_numero_contrato { get; set; }
        public static int sit_res_id_beneficio { get; set; }
        public static int sit_res_id_atecion_autoriza { get; set; }
        public static string sit_res_c_cod_autorizacion { get; set; }
        public static DateTime sit_res_d_fecha_autorizacion { get; set; }
        public static int sit_res_id_tipo_filiacion { get; set; }
        public static string sit_res_t_nombre_titular { get; set; }
        public static int sit_res_id_tipo_afiliacion { get; set; }
        public static int sit_res_id_moneda { get; set; }
        public static double sit_res_c_num_copago_fijo { get; set; }
        public static double sit_res_c_num_copago_variable { get; set; }
        public static int sit_res_id_producto_plan { get; set; }

        //cie10
        public static int cie10_id_cie10 { get; set; }
        public static string cie10_c_codigo { get; set; }
        public static string ci10_t_descripcion { get; set; }

    }
}
