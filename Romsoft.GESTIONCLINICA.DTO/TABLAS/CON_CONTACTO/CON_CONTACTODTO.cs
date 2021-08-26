using Romsoft.GESTIONCLINICA.DTO.Core;
using System;


namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.CON_CONTACTO
{
    public class CON_CONTACTODTO : EntityAuditableDTO
    {
        public int id_contacto { get; set; }
        public int id_tipo_contacto { get; set; }
        public string c_codigo { get; set; }
        public string c_codigo_sunat { get; set; }
        public string t_apellidos { get; set; }
        public string t_nombres { get; set; }
        public string t_razon_social { get; set; }
        public string t_razon_comercial { get; set; }
        public string t_observacion { get; set; }
        public string t_direccion { get; set; }
        public string t_contacto { get; set; }
        public string t_actividad_economica { get; set; }
        public string c_telefono1 { get; set; }
        public string c_telefono2 { get; set; }
        public string t_email_ffee { get; set; }
        public int n_dias_credito { get; set; }
        public int n_flag_garante { get; set; }
        public int n_flag_contratante { get; set; }
        public int n_flag_proveedor { get; set; }
        public int n_flag_habido { get; set; }
        public int f_estado { get; set; }
        public int id_user_registro { get; set; }
        public int Response { get; set; }

        public string codigo_tc { get; set; }
        public string estado { get; set; }

        public string valor { get; set; }
    }
}
