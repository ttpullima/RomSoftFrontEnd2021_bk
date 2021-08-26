using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romsoft.GESTIONCLINICA.Common
{
    public enum EstadoActual : int
    {
        Normal = 0,
        Nuevo = 1,   // Guardar
        Editar = 2,
        Eliminar = 3,
        Procesar = 4
    }

}
