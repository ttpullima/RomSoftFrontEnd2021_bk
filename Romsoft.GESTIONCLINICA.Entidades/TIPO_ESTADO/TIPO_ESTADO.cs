using Romsoft.GESTIONCLINICA.Entidades.Core;

namespace Romsoft.GESTIONCLINICA.Entidades.TIPO_ESTADO
{
    public class TIPO_ESTADO : EntityAuditable
    {
        public string tabla { get; set; }
        public int id_estado { get; set; }
        public string estado { get; set; }

    }
}
