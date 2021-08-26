using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Business.Logic.Tablas;
using Romsoft.GESTIONCLINICA.Entidades;
using Romsoft.GESTIONCLINICA.DTO;
using Romsoft.GESTIONCLINICA.WebApi.Core;
using Romsoft.GESTIONCLINICA.Common;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Romsoft.GESTIONCLINICA.DTO.AutoMapper;
namespace Romsoft.GESTIONCLINICA.WebApi.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost]
        public JsonResponse Login(DTO.TABLAS.SEG_USUARIO.LoginDTO loginDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {

                var usuario = SEG_USUARIOBL.Instancia.GetByUsername(loginDTO.Username,loginDTO.Password);

                if (usuario != null)
                    {
                        var usuarioLoginDTO = MapperHelper.Map<Entidades.SEG_USUARIO.SEG_USUARIO, DTO.TABLAS.SEG_USUARIO.SEG_USUARIOLoginDTO>(usuario);
                        jsonResponse.Data = usuarioLoginDTO;

                    LogBL.Instancia.Add(new Log
                    {
                        Accion = Mensajes.Login,
                        Controlador = Mensajes.AccountController,
                        Identificador = 0, //usuarioLoginDTO.id,
                            Mensaje = Mensajes.AccesoAlSistema,
                        Usuario = usuarioLoginDTO.usuario,
                        Objeto = JsonConvert.SerializeObject(usuarioLoginDTO)
                    }) ;
                    }
                    else
                    {
                        jsonResponse.Warning = true;
                        jsonResponse.Message = Mensajes.UsuarioNoExiste;
                    }
                
            }
            catch (Exception ex)
            {
                LogError(ex);
                jsonResponse.Success = false;
                jsonResponse.Message = Mensajes.IntenteloMasTarde;
            }

            return jsonResponse;
        }

    }
}
