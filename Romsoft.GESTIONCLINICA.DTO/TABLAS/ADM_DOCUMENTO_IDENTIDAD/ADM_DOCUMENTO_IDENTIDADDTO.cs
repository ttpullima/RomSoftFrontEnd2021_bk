using Romsoft.GESTIONCLINICA.DTO.Core;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_DOCUMENTO_IDENTIDAD
{
    public class ADM_DOCUMENTO_IDENTIDADDTO : EntityAuditableDTO
    {
        public int id_documento_identidad { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }
    }
}
