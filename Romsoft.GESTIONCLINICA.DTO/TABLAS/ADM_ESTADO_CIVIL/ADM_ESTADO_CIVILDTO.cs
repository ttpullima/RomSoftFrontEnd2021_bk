using Romsoft.GESTIONCLINICA.DTO.Core;
using System;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_ESTADO_CIVIL
{
    public class ADM_ESTADO_CIVILDTO : EntityAuditableDTO
    {
        public int id_estado_civil { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }
    }
}
