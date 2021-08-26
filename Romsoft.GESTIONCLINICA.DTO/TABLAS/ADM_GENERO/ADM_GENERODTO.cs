using Romsoft.GESTIONCLINICA.DTO.Core;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_GENERO
{
    public class ADM_GENERODTO : EntityAuditableDTO
    {
        public int id_genero { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }
    }
}
