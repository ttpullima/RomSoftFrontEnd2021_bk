using Romsoft.GESTIONCLINICA.DTO.Core;


namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_PRODUCTO_PLAN
{
    public class CVN_PRODUCTO_PLANDTO : EntityAuditableDTO
    {
        public int id_producto_plan { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }
        public string c_codigo_iafa { get; set; }
    }
}
