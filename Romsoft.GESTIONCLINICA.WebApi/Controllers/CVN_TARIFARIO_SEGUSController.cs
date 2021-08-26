using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Business.Logic.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CVN_TARIFARIO_SEGUS;
using Romsoft.GESTIONCLINICA.Entidades;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_TARIFARIO_SEGUS;
using Romsoft.GESTIONCLINICA.WebApi.Core;
using Romsoft.GESTIONCLINICA.Common;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Romsoft.GESTIONCLINICA.DTO.AutoMapper;

namespace Romsoft.GESTIONCLINICA.WebApi.Controllers
{
    public class CVN_TARIFARIO_SEGUSController : BaseController
    {
        [HttpPost]
        public JsonResponse Add(CVN_TARIFARIO_SEGUSDTO tarifarioDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                int resultado = 0;
                var tarifario = MapperHelper.Map<CVN_TARIFARIO_SEGUSDTO, CVN_TARIFARIO_SEGUS>(tarifarioDTO);

                if (!CVN_TARIFARIO_SEGUSBL.Instancia.Exists(tarifario))
                {
                    resultado = CVN_TARIFARIO_SEGUSBL.Instancia.Add(tarifario);

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
                    Usuario = tarifarioDTO.UsuarioCreacion,
                    Objeto = JsonConvert.SerializeObject(tarifarioDTO)
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
                    Usuario = tarifarioDTO.UsuarioCreacion,
                    Objeto = JsonConvert.SerializeObject(tarifarioDTO)
                });
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse GetAllFilters(CVN_TARIFARIO_SEGUSDTO tarifarioDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var tarifario = MapperHelper.Map<CVN_TARIFARIO_SEGUSDTO, CVN_TARIFARIO_SEGUS>(tarifarioDTO);

                var tarifaList = CVN_TARIFARIO_SEGUSBL.Instancia.GetAllFilters(tarifario);
                var tarifaDTOList = MapperHelper.Map<IEnumerable<CVN_TARIFARIO_SEGUS>, IEnumerable<CVN_TARIFARIO_SEGUSDTO>>(tarifaList);
                jsonResponse.Data = tarifaDTOList;
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
        public JsonResponse GetAllActives()
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                //var tarifario = MapperHelper.Map<CVN_TARIFARIO_SEGUSDTO, CVN_TARIFARIO_SEGUS>(listatarifarioDTO);

                var tarifaList = CVN_TARIFARIO_SEGUSBL.Instancia.GetAllActives();
                var tarifaDTOList = MapperHelper.Map<IEnumerable<CVN_TARIFARIO_SEGUS>, IEnumerable<CVN_TARIFARIO_LISTADTO>>(tarifaList);
                jsonResponse.Data = tarifaDTOList;
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
        public JsonResponse Update(CVN_TARIFARIO_SEGUSDTO tarifarioDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                var tarifario = MapperHelper.Map<CVN_TARIFARIO_SEGUSDTO, CVN_TARIFARIO_SEGUS>(tarifarioDTO);
                int resultado = CVN_TARIFARIO_SEGUSBL.Instancia.Update(tarifario);

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
                    Usuario = tarifarioDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(tarifarioDTO)
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
                    Usuario = tarifarioDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(tarifarioDTO)
                });
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse Delete(CVN_TARIFARIO_SEGUSDTO tarifarioDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                var tarifa = MapperHelper.Map<CVN_TARIFARIO_SEGUSDTO, CVN_TARIFARIO_SEGUS>(tarifarioDTO);
                int resultado = CVN_TARIFARIO_SEGUSBL.Instancia.Delete(tarifa);

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
                    Usuario = tarifarioDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(tarifarioDTO)
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
                    Usuario = tarifarioDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(tarifarioDTO)
                });
            }

            return jsonResponse;
        }


        [HttpPost]
        public JsonResponse GetById(CVN_TARIFARIO_SEGUSDTO tarifarioDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var tarifario = MapperHelper.Map<CVN_TARIFARIO_SEGUSDTO, CVN_TARIFARIO_SEGUS>(tarifarioDTO);

                var tarifaList = CVN_TARIFARIO_SEGUSBL.Instancia.GetById(tarifario);
                var tarifaDTOList = MapperHelper.Map<IEnumerable<CVN_TARIFARIO_SEGUS>, IEnumerable<CVN_TARIFARIO_SEGUSDTO>>(tarifaList);
                jsonResponse.Data = tarifaDTOList;
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
