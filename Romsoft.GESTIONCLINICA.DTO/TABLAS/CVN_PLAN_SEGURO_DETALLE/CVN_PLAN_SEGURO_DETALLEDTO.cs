using System;
using Romsoft.GESTIONCLINICA.DTO.Core;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_PLAN_SEGURO_DETALLE
{
    public class CVN_PLAN_SEGURO_DETALLEDTO : EntityAuditableDTO
    {
        public long id_plan_seguro_detalle { get; set; }
        public int id_plan_seguro { get; set; }
        public int id_beneficio { get; set; }
        public int id_moneda { get; set; }
        public decimal n_copago_fijo { get; set; }
        public decimal n_copago_variable { get; set; }
        public decimal n_copago_variable_farmacia { get; set; }
        public int f_estado { get; set; }

        public string codigo { get; set; }
        public string beneficio { get; set; }
        public string estado { get; set; }
        public string moneda { get; set; }
    }
}
