using System;

namespace Romsoft.GESTIONCLINICA.Entidades
{
    public class Log
    {
        public int Id { get; set; }
        public string DireccionIP { get; set; }
        public string Usuario { get; set; }
        public string Mensaje { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Objeto { get; set; }
        public int? Identificador { get; set; }
    }
}
