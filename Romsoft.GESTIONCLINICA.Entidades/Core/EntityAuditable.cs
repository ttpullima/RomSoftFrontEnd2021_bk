using System;

namespace Romsoft.GESTIONCLINICA.Entidades.Core
{
    public class EntityAuditable 
    {
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int id_usuarioCreacion { get; set; }
        public int id_usuarioModifica { get; set; }
    }
}
