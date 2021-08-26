using Romsoft.GESTIONCLINICA.DTO.Core;
using System;



namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_PLAN_SEGURO
{
    public class CVN_PLAN_SEGURODTO : EntityAuditableDTO
    {
        public int id_plan_seguro { get; set; }
        public int id_contacto_garante { get; set; }
        public int id_contacto_contratante { get; set; }
        public int id_categoria_pago { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }
        public string t_observacion { get; set; }
        public string c_codigo_iafa { get; set; }
        public DateTime d_fecha_i_vigencia { get; set; }
        public DateTime d_fecha_f_vigencia { get; set; }
        public string c_contrato { get; set; }
        public string c_certificado { get; set; }
        public int id_producto_plan { get; set; }
        public int f_estado { get; set; }
        public string estado { get; set; }
        public string valorRequest { get; set; }
        //Response
        public string garante { get; set; }
        public string contratante { get; set; }
        public string producto { get; set; }
    }
}
