using Romsoft.GESTIONCLINICA.DTO.Core;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.CON_TIPO_CONTACTO
{
    public class CON_TIPO_CONTACTODTO : EntityAuditableDTO
    {
        public string tabla { get; set; }
        public int id_tipo_contacto { get; set; }
        public string t_descripcion { get; set; }

    }
}
