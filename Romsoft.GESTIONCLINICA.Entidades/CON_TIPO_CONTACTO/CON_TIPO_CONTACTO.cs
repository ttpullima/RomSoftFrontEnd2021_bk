using Romsoft.GESTIONCLINICA.Entidades.Core;

namespace Romsoft.GESTIONCLINICA.Entidades.CON_TIPO_CONTACTO
{
    public class CON_TIPO_CONTACTO : EntityAuditable
    {
        public string tabla { get; set; }
        public int id_tipo_contacto { get; set; }
        public string t_descripcion { get; set; }

    }
}
