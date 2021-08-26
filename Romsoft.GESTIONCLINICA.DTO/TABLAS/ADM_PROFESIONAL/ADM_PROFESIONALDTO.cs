using Romsoft.GESTIONCLINICA.DTO.Core;
using System;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_PROFESIONAL
{
    public class ADM_PROFESIONALDTO : EntityAuditableDTO
    {
        public int id_profesional { get; set; }
        public string c_codigo { get; set; }
        public string t_apellidos { get; set; }
        public string t_nombres { get; set; }
        public string t_medico { get; set; }
        public string t_direccion { get; set; }
        public string t_observacion { get; set; }
        public DateTime d_fecha_nace { get; set; }
        public int id_genero { get; set; }
        public int id_tipo_documento { get; set; }
        public string c_numero_documento { get; set; }
        public int id_especialidad { get; set; }
        public string c_nro_especialidad { get; set; }
        public int id_tipo_profesional { get; set; }
        public string c_colegiatura { get; set; }
        public int id_condicion_profesional { get; set; }
        public string c_telefono_1 { get; set; }
        public string c_telefono_2 { get; set; }
        public int f_estado { get; set; }
        public int id_user_registro { get; set; }
        public int id_user_modifica { get; set; }
        public DateTime d_fecha_registro { get; set; }
        public DateTime d_fecha_modifica { get; set; }
        public string valor { get; set; }
        public string descripcion_medico { get; set; }
        public string codigo { get; set; }
        public string genero { get; set; }
        public string especialidad { get; set; }
        public string tipo_profesional { get; set; }
        public string condicion_profesional { get; set; }
        public string telefono { get; set; }
        public string estado { get; set; }
    }
}
