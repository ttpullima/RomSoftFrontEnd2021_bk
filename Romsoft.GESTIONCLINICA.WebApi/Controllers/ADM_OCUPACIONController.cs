using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Business.Logic.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.ADM_OCUPACION;
using Romsoft.GESTIONCLINICA.Entidades;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_OCUPACION;
using Romsoft.GESTIONCLINICA.WebApi.Core;
using Romsoft.GESTIONCLINICA.Common;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Romsoft.GESTIONCLINICA.DTO.AutoMapper;

namespace Romsoft.GESTIONCLINICA.WebApi.Controllers
{
    public class ADM_OCUPACIONController : BaseController
    {
        [HttpPost]
        public JsonResponse Add(ADM_OCUPACIONDTO ocupacionDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                int resultado = 0;
                var ocupacion = MapperHelper.Map<ADM_OCUPACIONDTO, ADM_OCUPACION>(ocupacionDTO);

                if (!ADM_OCUPACIONBL.Instancia.Exists(ocupacion))
                {
                    resultado = ADM_OCUPACIONBL.Instancia.Add(ocupacion);

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
                    Usuario = ocupacionDTO.UsuarioCreacion,
                    Objeto = JsonConvert.SerializeObject(ocupacionDTO)
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
                    Usuario = ocupacionDTO.UsuarioCreacion,
                    Objeto = JsonConvert.SerializeObject(ocupacionDTO)
                });
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse Delete(ADM_OCUPACIONDTO ocupacionDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                var ocupacion = MapperHelper.Map<ADM_OCUPACIONDTO, ADM_OCUPACION>(ocupacionDTO);
                int resultado = ADM_OCUPACIONBL.Instancia.Delete(ocupacion);

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
                    Usuario = ocupacionDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(ocupacionDTO)
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
                    Usuario = ocupacionDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(ocupacionDTO)
                });
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse GetAllFilters(ADM_OCUPACIONDTO ocupacionDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var usuario = MapperHelper.Map<ADM_OCUPACIONDTO, ADM_OCUPACION>(ocupacionDTO);

                var ocupacionList = ADM_OCUPACIONBL.Instancia.GetAllFilters(usuario);
                var ocupacionDTOList = MapperHelper.Map<IEnumerable<ADM_OCUPACION>, IEnumerable<ADM_OCUPACIONDTO>>(ocupacionList);
                jsonResponse.Data = ocupacionDTOList;
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
        public JsonResponse GetById(ADM_OCUPACIONDTO ocupacionDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var ocupacion = MapperHelper.Map<ADM_OCUPACIONDTO, ADM_OCUPACION>(ocupacionDTO);
                var ocupacionList = ADM_OCUPACIONBL.Instancia.GetById(ocupacion);
                if (ocupacionList != null)
                {
                    var usuarioDTOList = MapperHelper.Map<IEnumerable<ADM_OCUPACION>, IEnumerable<ADM_OCUPACIONDTO>>(ocupacionList);
                    jsonResponse.Data = usuarioDTOList;
                }
                else
                {
                    jsonResponse.Warning = true;
                    jsonResponse.Message = Mensajes.OcupacionNoExiste;
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
        public JsonResponse Update(ADM_OCUPACIONDTO ocupacionDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                var ocupacion = MapperHelper.Map<ADM_OCUPACIONDTO, ADM_OCUPACION>(ocupacionDTO);
                int resultado = ADM_OCUPACIONBL.Instancia.Update(ocupacion);

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
                    Usuario = ocupacionDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(ocupacionDTO)
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
                    Usuario = ocupacionDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(ocupacionDTO)
                });
            }

            return jsonResponse;
        }

        //Obtiene Lista de ocupación Activos
        [HttpPost]
        public JsonResponse GetAllActives()
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var ocupacionList = ADM_OCUPACIONBL.Instancia.GetAllActives();
                var ocupacionDTOList = MapperHelper.Map<IEnumerable<ADM_OCUPACION>, IEnumerable<ADM_OCUPACIONDTO>>(ocupacionList);
                jsonResponse.Data = ocupacionDTOList;
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
