using Romsoft.GESTIONCLINICA.Entidades.Core;
using System;

namespace Romsoft.GESTIONCLINICA.Entidades.ADM_DOCUMENTO_AUTORIZACION
{
    public class ADM_DOCUMENTO_AUTORIZACION : EntityAuditable
    {
        public string COD_DOCUMENTO { get; set; }
        public string COD_AUTORIZACION { get; set; }
        public string COD_ASEGURADO { get; set; }
        public DateTime FEC_AUTORIZACION { get; set; }
        public DateTime FEC_NACIMIENTO { get; set; }
        public string NOMBRES { get; set; }
        public string AP_PATERNO { get; set; }
        public string AP_MATERNO { get; set; }
        public string PACIENTE { get; set; }
        public string TITULAR { get; set; }
        public string RUC_IPRESS { get; set; }
        public string COD_IAFA { get; set; }
        public decimal NUM_COPAGO_FIJO { get; set; }
        public decimal NUM_COPAGO_VARIABLE { get; set; }
        public string COD_IPRESS { get; set; }
        public string SEXO { get; set; }
        public string NUM_DOCUMENTO { get; set; }
        public string NUM_EDAD { get; set; }
        public string COD_ASEGURADO_TITULAR { get; set; }
        public string COD_DOCUMENTO_TITULAR { get; set; }
        public string NUM_DOCUMENTO_TITULAR { get; set; }
        public string COD_TIPO_FILIACION { get; set; }
        public string DES_TIPO_FILIACION { get; set; }
        public string COD_COBERTURA { get; set; }
        public string COD_SUBCOBERTURA { get; set; }
        public string DES_BENEFICIO { get; set; }
        public string COD_PRODUCTO { get; set; }
        public string DES_PRODUCTO { get; set; }
        public string COD_TIPOPLAN { get; set; }
        public string DES_TIPOPLAN { get; set; }
        public string COD_TIPO_AFILIACION { get; set; }
        public string DES_TIPO_AFILIACION { get; set; }
        public string NUM_POLIZA { get; set; }
        public string NUM_PLAN { get; set; }
        public string COD_CONTRATANTE { get; set; }
        public string COD_CONTRATANTE_ABR { get; set; }
        public string NUM_CONTRATANTE { get; set; }
        public string DES_CONTRATANTE { get; set; }
        public DateTime FEC_INICIO_VIGENCIA { get; set; }
        public DateTime FEC_FIN_VIGENCIA { get; set; }
        public DateTime FE_INCLDATE { get; set; }
        public string COD_MONEDA { get; set; }
        public string COD_SERVICIO { get; set; }
        public string NUM_IP { get; set; }
        public int f_estado { get; set; }
        public int id_user_registro { get; set; }
        public int id_user_modifica { get; set; }
        public string valor { get; set; }
    }
}
