using Romsoft.GESTIONCLINICA.DTO.Core;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.SEG_ROL
{
    public class SEG_ROLDTO : EntityAuditableDTO
    {
        public int id_rol { get; set; }
        public string rol { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
    }
}
