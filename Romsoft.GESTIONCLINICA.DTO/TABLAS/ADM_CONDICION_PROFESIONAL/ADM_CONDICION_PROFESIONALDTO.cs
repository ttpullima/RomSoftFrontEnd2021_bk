using Romsoft.GESTIONCLINICA.DTO.Core;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_CONDICION_PROFESIONAL
{
    public class ADM_CONDICION_PROFESIONALDTO : EntityAuditableDTO
    {
        public int id_condicion_profesional { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }
    }
}
