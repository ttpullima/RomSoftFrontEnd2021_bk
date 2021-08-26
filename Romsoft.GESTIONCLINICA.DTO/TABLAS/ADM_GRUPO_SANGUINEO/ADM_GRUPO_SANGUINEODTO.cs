using Romsoft.GESTIONCLINICA.DTO.Core;
using System;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_GRUPO_SANGUINEO
{
    public class ADM_GRUPO_SANGUINEODTO : EntityAuditableDTO
    {
        public int id_grupo_sanguineo { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }
    }
}
