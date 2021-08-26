using Romsoft.GESTIONCLINICA.DTO.Core;


namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.TIPO_ESTADO
{
    public class TIPO_ESTADODTO : EntityAuditableDTO
    {
        public string tabla { get; set; }
        public int id_estado { get; set; }
        public string estado { get; set; }
    }
}
