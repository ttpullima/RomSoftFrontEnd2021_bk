using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.Entidades.ADM_DOCUMENTO_AUTORIZACION
{
    public class ADM_DOCUMENTO_AUTORIZACION_REQ
    {
        public int idUser { get; set; }
        public List<ADM_DOCUMENTO_AUTORIZACION> listaAutoriza { get; set; }
    }
}
