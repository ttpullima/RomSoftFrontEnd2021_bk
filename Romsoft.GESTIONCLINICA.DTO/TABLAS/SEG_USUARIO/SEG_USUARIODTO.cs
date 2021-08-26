using Romsoft.GESTIONCLINICA.DTO.Core;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.SEG_USUARIO
{
    public class SEG_USUARIODTO : EntityAuditableDTO
    {
        public int id_usuario { get; set; }
        public int id_rol { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string apellidos { get; set; }
        public string nombres { get; set; }
        public string nro_documento { get; set; }
        public string sexo { get; set; }
        public string email { get; set; }
        public string celular { get; set; }
        public string estado { get; set; }

        // Solo para response
        public string RolNombre { get; set; }
        public int Cantidad { get; set; }
    }
}
