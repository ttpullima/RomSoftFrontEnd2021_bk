using Romsoft.GESTIONCLINICA.DTO.Core;

namespace Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_TARIFARIO_SEGUS_PARTICIPANTE
{
    public class CVN_TARIFARIO_SEGUS_PARTICIPANTEDTO : EntityAuditableDTO
    {
        public int id_tarifario_segus_participante { get; set; } //idTabla
        public int id_tarifario_segus { get; set; } //-- PAPA
        public int id_tarifario_segus_referencia { get; set; } //--HIJOS

        //Response
        public string c_codigo { get; set; }
        public string t_descripcion_esp { get; set; }
    }
}
