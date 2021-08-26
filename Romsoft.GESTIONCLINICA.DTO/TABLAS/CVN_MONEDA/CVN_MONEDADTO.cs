using Romsoft.GESTIONCLINICA.DTO.Core;
using System;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_MONEDA
{
    public class CVN_MONEDADTO : EntityAuditableDTO
    {
        public int id_moneda { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }
    }
}
