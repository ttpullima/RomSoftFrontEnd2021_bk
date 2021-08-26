using Romsoft.GESTIONCLINICA.DTO.Core;
using System;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_PACIENTE
{
    public class ADM_PACIENTEDTO : EntityAuditableDTO
    {
        public int id_paciente { get; set; }
        public int n_historia_clinica { get; set; }
        public string t_apellido_paterno { get; set; }
        public string t_apellido_materno { get; set; }
        public string t_nombres { get; set; }
        public string t_paciente { get; set; }
        public DateTime d_fecha_nacimiento { get; set; }
        public int id_genero { get; set; }
        public int id_estado_civil { get; set; }
        public int id_documento_identidad { get; set; }
        public string c_documento_identidad { get; set; }
        public int id_grupo_sanguineo { get; set; }
        public int id_ocupacion { get; set; }
        public string t_ocupacion { get; set; }
        public string t_email_paciente { get; set; }
        public string c_p_fono_casa { get; set; }
        public string c_p_fono_personal { get; set; }
        public string c_p_fono_corporativo { get; set; }
        public int id_ubigeo_nacimiento { get; set; }
        public int id_ubigeo_domicilio { get; set; }
        public string t_referencia { get; set; }
        public string t_direccion { get; set; }
        public string t_responsable { get; set; }
        public string t_email_responsable { get; set; }
        public string c_r_fono_casa { get; set; }
        public string c_r_fono_personal { get; set; }
        public int f_estado { get; set; }

        public string valorRequest { get; set; }
        public string historia_clinica { get; set; }
        public string sexo { get; set; }
        public string t_documento { get; set; }
        public string des_ubigeo_nacimiento { get; set; }
        public string des_ubigeo_domicilio { get; set; }
        public string des_estadocivil { get; set; }
    }
}
