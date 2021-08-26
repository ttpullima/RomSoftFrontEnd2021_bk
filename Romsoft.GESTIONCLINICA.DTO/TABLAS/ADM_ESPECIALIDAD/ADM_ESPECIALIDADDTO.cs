using Romsoft.GESTIONCLINICA.DTO.Core;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_ESPECIALIDAD
{
    public class ADM_ESPECIALIDADDTO : EntityAuditableDTO
    {
        public int id_especialidad { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }
    }
}
