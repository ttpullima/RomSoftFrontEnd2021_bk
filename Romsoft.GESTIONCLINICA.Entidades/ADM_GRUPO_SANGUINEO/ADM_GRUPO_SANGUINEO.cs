using Romsoft.GESTIONCLINICA.Entidades.Core;


namespace Romsoft.GESTIONCLINICA.Entidades.ADM_GRUPO_SANGUINEO
{
    public class ADM_GRUPO_SANGUINEO : EntityAuditable
    {
        public int id_grupo_sanguineo { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }
    }
}
