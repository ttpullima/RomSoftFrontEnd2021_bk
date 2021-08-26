using Romsoft.GESTIONCLINICA.Entidades.Core;
using System;

namespace Romsoft.GESTIONCLINICA.Entidades.ADM_ATENCION
{
    public class ADM_ATENCION_ResponseGetAllActives : EntityAuditable
    {
        public int id_atencion { get; set; }
        public DateTime d_fecha_registro { get; set; }
        public string c_hora_registro { get; set; }
        public string HClinica { get; set; }
        public string Paciente { get; set; }
        public string Garante { get; set; }
        public string Prestacion { get; set; }
        public string TAtencion { get; set; }
        public string TPaciente { get; set; }
        public string Estado { get; set; }
        public string FEstado { get; set; }
    }
}
