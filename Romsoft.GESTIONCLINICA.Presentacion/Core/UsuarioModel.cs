using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romsoft.GESTIONCLINICA.Presentacion.Core
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string usuario { get; set; }
        public string Password { get; set; }
        public int id_rol { get; set; }
        public string RolNombre { get; set; }
        public string TimeZoneId { get; set; }
        public int TimeZoneGMT { get; set; }
        public int id_usuario { get; set; }
        public string estado { get; set; }
        public string apellidos { get; set; }
        public string nombres { get; set; }
    }
}
