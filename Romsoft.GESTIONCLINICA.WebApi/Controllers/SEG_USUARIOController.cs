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
    public class SEG_USUARIOController : BaseController
    {
        [HttpPost]
        public JsonResponse Add(DTO.TABLAS.SEG_USUARIO.SEG_USUARIODTO usuarioDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                int resultado = 0;
                var usuario = MapperHelper.Map<DTO.TABLAS.SEG_USUARIO.SEG_USUARIODTO, Entidades.SEG_USUARIO.SEG_USUARIO>(usuarioDTO);

                if (!SEG_USUARIOBL.Instancia.Exists(usuario))
                {
                    resultado = SEG_USUARIOBL.Instancia.Add(usuario);

                    if (resultado > 0)
                    {
                        jsonResponse.Message = Mensajes.RegistroSatisfactorio;
                    }
                    else
                    {
                        jsonResponse.Warning = true;
                        jsonResponse.Message = Mensajes.RegistroFallido;
                    }
                }
                else
                {
                    jsonResponse.Warning = true;
                    jsonResponse.Message = Mensajes.YaExisteRegistro;
                }

                LogBL.Instancia.Add(new Log
                {
                    Accion = Mensajes.Add,
                    Controlador = Mensajes.UsuarioController,
                    Identificador = resultado,
                    Mensaje = jsonResponse.Message,
                    Usuario = usuarioDTO.UsuarioCreacion,
                    Objeto = JsonConvert.SerializeObject(usuarioDTO)
                });
            }
            catch (Exception ex)
            {
                LogError(ex);
                jsonResponse.Success = false;
                jsonResponse.Message = Mensajes.IntenteloMasTarde;

                LogBL.Instancia.Add(new Log
                {
                    Accion = Mensajes.Add,
                    Controlador = Mensajes.UsuarioController,
                    Identificador = 0,
                    Mensaje = ex.Message,
                    Usuario = usuarioDTO.UsuarioCreacion,
                    Objeto = JsonConvert.SerializeObject(usuarioDTO)
                });
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse Delete(DTO.TABLAS.SEG_USUARIO.SEG_USUARIODTO usuarioDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                var usuario = MapperHelper.Map<DTO.TABLAS.SEG_USUARIO.SEG_USUARIODTO, Entidades.SEG_USUARIO.SEG_USUARIO>(usuarioDTO);
                int resultado = SEG_USUARIOBL.Instancia.Delete(usuario);

                if (resultado > 0)
                {
                    jsonResponse.Message = Mensajes.EliminacionSatisfactoria;
                }
                else
                {
                    jsonResponse.Warning = true;
                    jsonResponse.Message = Mensajes.EliminacionFallida;
                }
                LogBL.Instancia.Add(new Log
                {
                    Accion = Mensajes.Delete,
                    Controlador = Mensajes.UsuarioController,
                    Identificador = resultado,
                    Mensaje = jsonResponse.Message,
                    Usuario = usuarioDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(usuarioDTO)
                });

            }
            catch (Exception ex)
            {
                LogError(ex);
                jsonResponse.Success = false;
                jsonResponse.Message = Mensajes.IntenteloMasTarde;

                LogBL.Instancia.Add(new Log
                {
                    Accion = Mensajes.Delete,
                    Controlador = Mensajes.UsuarioController,
                    Identificador = 0,
                    Mensaje = ex.Message,
                    Usuario = usuarioDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(usuarioDTO)
                });
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse GetAllPaging(PaginationParameter paginationParameters)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var usuarioList = SEG_USUARIOBL.Instancia.GetAllPaging(paginationParameters);
                var usuarioDTOList = MapperHelper.Map<IEnumerable<Entidades.SEG_USUARIO.SEG_USUARIO>, IEnumerable<DTO.TABLAS.SEG_USUARIO.SEG_USUARIODTO>>(usuarioList);
                jsonResponse.Data = usuarioDTOList;
            }
            catch (Exception ex)
            {
                LogError(ex);
                jsonResponse.Success = false;
                jsonResponse.Message = Mensajes.IntenteloMasTarde;
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse GetAllFilters(DTO.TABLAS.SEG_USUARIO.SEG_USUARIODTO usuarioDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var usuario = MapperHelper.Map<DTO.TABLAS.SEG_USUARIO.SEG_USUARIODTO, Entidades.SEG_USUARIO.SEG_USUARIO>(usuarioDTO);

                var usuarioList = SEG_USUARIOBL.Instancia.GetAllFilters(usuario);
                var usuarioDTOList = MapperHelper.Map<IEnumerable<Entidades.SEG_USUARIO.SEG_USUARIO>, IEnumerable<DTO.TABLAS.SEG_USUARIO.SEG_USUARIODTO>>(usuarioList);
                jsonResponse.Data = usuarioDTOList;
            }
            catch (Exception ex)
            {
                LogError(ex);
                jsonResponse.Success = false;
                jsonResponse.Message = Mensajes.IntenteloMasTarde;
            }

            return jsonResponse;
        }


        [HttpPost]
        public JsonResponse GetById(DTO.TABLAS.SEG_USUARIO.SEG_USUARIODTO usuarioDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var usuario = MapperHelper.Map<DTO.TABLAS.SEG_USUARIO.SEG_USUARIODTO, Entidades.SEG_USUARIO.SEG_USUARIO>(usuarioDTO);
                var usuarioList = SEG_USUARIOBL.Instancia.GetById(usuario);
                if (usuarioList != null)
                {
                   var usuarioDTOList = MapperHelper.Map<IEnumerable<Entidades.SEG_USUARIO.SEG_USUARIO>, IEnumerable<DTO.TABLAS.SEG_USUARIO.SEG_USUARIODTO>>(usuarioList);
                    jsonResponse.Data = usuarioDTOList;
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

        [HttpPost]
        public JsonResponse GetByUsername(DTO.TABLAS.SEG_USUARIO.SEG_USUARIODTO loginDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var usuario = SEG_USUARIOBL.Instancia.GetByUsername(loginDTO.usuario,loginDTO.clave);
                if (usuario != null)
                {
                    var usuarioLoginDTO = MapperHelper.Map<Entidades.SEG_USUARIO.SEG_USUARIO, DTO.TABLAS.SEG_USUARIO.SEG_USUARIODTO>(usuario);
                    jsonResponse.Data = usuarioLoginDTO;
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

        [HttpPost]
        public JsonResponse Update(DTO.TABLAS.SEG_USUARIO.SEG_USUARIODTO usuarioDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                var usuario = MapperHelper.Map<DTO.TABLAS.SEG_USUARIO.SEG_USUARIODTO, Entidades.SEG_USUARIO.SEG_USUARIO>(usuarioDTO);
                int resultado = SEG_USUARIOBL.Instancia.Update(usuario);

                if (resultado > 0)
                {
                    jsonResponse.Message = Mensajes.ActualizacionSatisfactoria;
                }
                else
                {
                    jsonResponse.Warning = true;
                    jsonResponse.Message = Mensajes.ActualizacionFallida;
                }

                LogBL.Instancia.Add(new Log
                {
                    Accion = Mensajes.Update,
                    Controlador = Mensajes.UsuarioController,
                    Identificador = resultado,
                    Mensaje = jsonResponse.Message,
                    Usuario = usuarioDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(usuarioDTO)
                });
            }
            catch (Exception ex)
            {
                LogError(ex);
                jsonResponse.Success = false;
                jsonResponse.Message = Mensajes.IntenteloMasTarde;

                LogBL.Instancia.Add(new Log
                {
                    Accion = Mensajes.Update,
                    Controlador = Mensajes.UsuarioController,
                    Identificador = 0,
                    Mensaje = ex.Message,
                    Usuario = usuarioDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(usuarioDTO)
                });
            }

            return jsonResponse;
        }

    }
}
