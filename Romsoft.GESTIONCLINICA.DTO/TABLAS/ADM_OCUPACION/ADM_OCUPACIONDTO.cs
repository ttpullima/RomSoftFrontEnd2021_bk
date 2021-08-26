using System;
using Romsoft.GESTIONCLINICA.DTO.Core;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_OCUPACION
{
    public class ADM_OCUPACIONDTO : EntityAuditableDTO
    {
        public int id_ocupacion { get; set; }
        public string c_codigo { get; set; }
        public string t_descripcion { get; set; }
        public string t_observacion { get; set; }
        public Nullable<int> f_estado { get; set; }
        public string estado { get; set; }      //Descripción estado
    }
}
