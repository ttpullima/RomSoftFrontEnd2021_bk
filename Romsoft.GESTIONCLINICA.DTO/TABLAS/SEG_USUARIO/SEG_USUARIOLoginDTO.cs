using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.SEG_USUARIO
{
    public class SEG_USUARIOLoginDTO
    {
        public int id_usuario { get; set; }
        public int id_rol { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string apellidos { get; set; }
        public string nombres { get; set; }
        public string estado { get; set; }
    }
}
