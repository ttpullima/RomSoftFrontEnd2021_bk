using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Romsoft.GESTIONCLINICA.WebApi.Core
{
    public class Mensajes
    {
        public static string IntenteloMasTarde = "Hubo un error, inténtelo más tarde.";
        public static string UsuarioNoExiste = "El usuario no pertenece al sistema.";
        public static string RolNoExiste = "El rol no pertenece al sistema.";
        public static string OcupacionNoExiste = "La ocupación no pertenece al sistema.";
        public static string RegistroSatisfactorio = "Se registró satisfactoriamente.";
        public static string RegistroFallido = "No se pudo realizar el registro.";
        public static string ActualizacionSatisfactoria = "Se actualizó satisfactoriamente.";
        public static string ActualizacionFallida = "No se pudo realizar la actualización.";
        public static string EliminacionSatisfactoria = "Se eliminó satisfactoriamente.";
        public static string EliminacionFallida = "No se pudo realizar la eliminación.";
        public static string NoExisteRegistro = "No existe el registro solicitado.";
        public static string YaExisteDescripcion = "Ya existe un descripción, por lo tanto no se puede registrar.";
        public static string YaExisteDescripcionBF = "Ya existe descripción BF, por lo tanto no se puede registrar.";
        public static string YaExisteRegistro = "El registro ya existe.";
        public static string CargoCorrectamente = "Se cargó correctamente.";
        public static string MetasCargadas = "Estas metas ya están cargada.";
        public static string ExisteReporte = "Ya se generó el reporte anteriormente.";
        public static string NoHuboActualizacionData = "No hubo actualización de data";
        public static string UnActivo = "Solo puede haber un activo.";
        public static string YaExisteZonaAsignada = "Ya existe zona asignada activa.";
        public static string NoExisteMeta = "No existe meta para este periodo";
        public static string VerificarDelete = "Hay datos que dependen de él,elimínelos para que pueda eliminar este registro.";
        public static string VerificarDesactivar = "Hay datos que dependen de él,desactívelos para que pueda desactivar este registro.";

        public static string CredencialesDominioIncorrectas = "Las credenciales de Dominio son Incorrectas";
        public static string AccesoAlSistema = "Acceso al sistema";

        public static string AccountController = "Account";
        public static string TipoZonaController = "TipoZona";
        public static string ExclusionController = "Exclusión";
        public static string UsuarioController = "Usuario";
        public static string RolController = "Rol";
        public static string EncargadoController = "Encargado";
        public static string ZonaController = "Zona";
        public static string EncargadoZonaController = "EncargadoZona";
        public static string CategoriaController = "Categoria";
        public static string CategoriaTiendaController = "CategoriaTienda";
        public static string TiendaController = "Tienda";
        public static string ItemController = "Item";
        public static string FormulaController = "Formula";
        public static string ContactoController = "Contacto";
        public static string SemaforoController = "Semaforo";
        public static string MetaController = "Meta";
        public static string ReporteController = "Reporte";
        public static string Add = "Add";
        public static string Delete = "Delete";
        public static string Login = "Login";
        public static string Update = "Update";
        public static string AddDetalleGrupal = "AddDetalleGrupal";
    }
}