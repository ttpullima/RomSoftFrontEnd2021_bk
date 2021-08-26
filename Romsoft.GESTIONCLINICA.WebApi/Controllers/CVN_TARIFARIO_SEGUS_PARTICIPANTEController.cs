using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Business.Logic.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CVN_TARIFARIO_SEGUS_PARTICIPANTE;
using Romsoft.GESTIONCLINICA.Entidades;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_TARIFARIO_SEGUS_PARTICIPANTE;
using Romsoft.GESTIONCLINICA.WebApi.Core;
using Romsoft.GESTIONCLINICA.Common;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Romsoft.GESTIONCLINICA.DTO.AutoMapper;

namespace Romsoft.GESTIONCLINICA.WebApi.Controllers
{
    public class CVN_TARIFARIO_SEGUS_PARTICIPANTEController : BaseController
    {
        [HttpPost]
        public JsonResponse Add(CVN_TARIFARIO_SEGUS_PARTICIPANTEDTO tarifarioDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                int resultado = 0;
                var participante = MapperHelper.Map<CVN_TARIFARIO_SEGUS_PARTICIPANTEDTO, CVN_TARIFARIO_SEGUS_PARTICIPANTE>(tarifarioDTO);

                if (!CVN_TARIFARIO_SEGUS_PARTICIPANTEBL.Instancia.Exists(participante))
                {
                    resultado = CVN_TARIFARIO_SEGUS_PARTICIPANTEBL.Instancia.Add(participante);

                    if (resultado > 0)
                    {
                        jsonResponse.Message = Mensajes.RegistroSatisfactorio;
                        jsonResponse.Data = resultado;
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
        public JsonResponse Delete(CVN_TARIFARIO_SEGUS_PARTICIPANTEDTO tarifarioDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                var participante = MapperHelper.Map<CVN_TARIFARIO_SEGUS_PARTICIPANTEDTO, CVN_TARIFARIO_SEGUS_PARTICIPANTE>(tarifarioDTO);
                int resultado = CVN_TARIFARIO_SEGUS_PARTICIPANTEBL.Instancia.Delete(participante);

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
        public JsonResponse GetAllActivesFilters(CVN_TARIFARIO_SEGUS_PARTICIPANTEDTO participanteDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var participantes = MapperHelper.Map<CVN_TARIFARIO_SEGUS_PARTICIPANTEDTO, CVN_TARIFARIO_SEGUS_PARTICIPANTE>(participanteDTO);

                var participanteList = CVN_TARIFARIO_SEGUS_PARTICIPANTEBL.Instancia.GetAllActivesFilters(participantes);
                var participanteDTOList = MapperHelper.Map<IEnumerable<CVN_TARIFARIO_SEGUS_PARTICIPANTE>, IEnumerable<CVN_TARIFARIO_SEGUS_PARTICIPANTEDTO>>(participanteList);
                jsonResponse.Data = participanteDTOList;
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
