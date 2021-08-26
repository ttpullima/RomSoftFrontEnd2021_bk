using Romsoft.GESTIONCLINICA.Entidades.Core;

namespace Romsoft.GESTIONCLINICA.Entidades.SEG_ROL
{
    public class SEG_ROL : EntityAuditable
    {
       public int id_rol { get; set; }
       public string rol { get; set; }
       public string descripcion { get; set; }
       public string estado { get; set; }
    }
}
