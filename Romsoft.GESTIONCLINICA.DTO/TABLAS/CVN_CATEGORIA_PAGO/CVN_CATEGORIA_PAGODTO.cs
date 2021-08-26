using Romsoft.GESTIONCLINICA.DTO.Core;
using System;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_CATEGORIA_PAGO
{
    public class CVN_CATEGORIA_PAGODTO : EntityAuditableDTO
    {
        public int id_categoria_pago { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }

        //--- new
        public string t_observacion { get; set; }
        public DateTime? d_fecha_i_vigencia { get; set; }
        public DateTime? d_fecha_f_vigencia { get; set; }
        public decimal n_factor_servicio { get; set; }
        public decimal n_factor_procedimiento { get; set; }
        public decimal n_dscto_farmacia { get; set; }
        public int f_estado { get; set; }

        public string estado { get; set; }
        public string valorConsulta { get; set; }
    }
}
