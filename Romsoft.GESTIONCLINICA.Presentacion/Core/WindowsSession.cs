
using System.Collections.Generic;


namespace Romsoft.GESTIONCLINICA.Presentacion.Core
{
    public class WindowsSession
    {
        public static int UserIdActual { get; set; }
        public static int RolIdActual { get; set; }
        public static string RazonSocial { get { return "OXYGEN MEDICAL NETWORK"; } }
        public static string Rubro { get { return "SALUD"; } }
        public static string RUC { get { return ""; } }
        public static string UsuarioActual { get; set; }
        public static string nombreUsuario { get; set; }

        //public static List<FormularioDTO> FormularioList { get; set; }
        //public static List<FormularioDTO> MenuList { get; set; }
    }

}
