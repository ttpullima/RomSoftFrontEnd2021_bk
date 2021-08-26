using Romsoft.GESTIONCLINICA.DTO.Core;
using System;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_BENEFICIO
{
    public class CVN_BENEFICIODTO : EntityAuditableDTO
    {
        public int id_beneficio { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }

    }
}
