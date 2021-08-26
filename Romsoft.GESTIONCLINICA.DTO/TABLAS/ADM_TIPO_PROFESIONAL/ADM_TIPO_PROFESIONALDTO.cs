using Romsoft.GESTIONCLINICA.DTO.Core;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_TIPO_PROFESIONAL
{
    public class ADM_TIPO_PROFESIONALDTO : EntityAuditableDTO
    {
        public int id_tipo_profesional { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }
    }
}
