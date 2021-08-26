using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Business.Logic.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CVN_CATEGORIA_PAGO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_CATEGORIA_PAGO;
using Romsoft.GESTIONCLINICA.WebApi.Core;
using Romsoft.GESTIONCLINICA.Common;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Romsoft.GESTIONCLINICA.DTO.AutoMapper;
using Romsoft.GESTIONCLINICA.Entidades;

namespace Romsoft.GESTIONCLINICA.WebApi.Controllers
{
    public class CVN_CATEGORIA_PAGOController : BaseController
    {
        [HttpPost]
        public JsonResponse Add(CVN_CATEGORIA_PAGODTO catpagoDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                int resultado = 0;
                var catpago = MapperHelper.Map<CVN_CATEGORIA_PAGODTO, CVN_CATEGORIA_PAGO>(catpagoDTO);

                if (!CVN_CATEGORIA_PAGOBL.Instancia.Exists(catpago))
                {
                    resultado = CVN_CATEGORIA_PAGOBL.Instancia.Add(catpago);

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
                    Usuario = catpagoDTO.UsuarioCreacion,
                    Objeto = JsonConvert.SerializeObject(catpagoDTO)
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
                    Usuario = catpagoDTO.UsuarioCreacion,
                    Objeto = JsonConvert.SerializeObject(catpagoDTO)
                });
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse Delete(CVN_CATEGORIA_PAGODTO catpagoDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                var catpago = MapperHelper.Map<CVN_CATEGORIA_PAGODTO, CVN_CATEGORIA_PAGO>(catpagoDTO);
                int resultado = CVN_CATEGORIA_PAGOBL.Instancia.Delete(catpago);

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
                    Usuario = catpagoDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(catpagoDTO)
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
                    Usuario = catpagoDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(catpagoDTO)
                });
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse Update(CVN_CATEGORIA_PAGODTO catpagoDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                var ocupacion = MapperHelper.Map<CVN_CATEGORIA_PAGODTO, CVN_CATEGORIA_PAGO>(catpagoDTO);
                int resultado = CVN_CATEGORIA_PAGOBL.Instancia.Update(ocupacion);

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
                    Usuario = catpagoDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(catpagoDTO)
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
                    Usuario = catpagoDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(catpagoDTO)
                });
            }

            return jsonResponse;
        }


        [HttpPost]
        public JsonResponse GetById(CVN_CATEGORIA_PAGODTO catpagoDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var catpago = MapperHelper.Map<CVN_CATEGORIA_PAGODTO, CVN_CATEGORIA_PAGO>(catpagoDTO);
                var catpagoList = CVN_CATEGORIA_PAGOBL.Instancia.GetById(catpago);
                if (catpagoList != null)
                {
                    var catpagoDTOList = MapperHelper.Map<IEnumerable<CVN_CATEGORIA_PAGO>, IEnumerable<CVN_CATEGORIA_PAGODTO>>(catpagoList);
                    jsonResponse.Data = catpagoDTOList;
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


        //Obtiene activos
        [HttpPost]
        public JsonResponse GetAllActives(CVN_CATEGORIA_PAGODTO catpagoDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var catpago = MapperHelper.Map<CVN_CATEGORIA_PAGODTO, CVN_CATEGORIA_PAGO>(catpagoDTO);

                var catpagoList = CVN_CATEGORIA_PAGOBL.Instancia.GetAllActives();
                var catpagoDTOList = MapperHelper.Map<IEnumerable<CVN_CATEGORIA_PAGO>, IEnumerable<CVN_CATEGORIA_PAGODTO>>(catpagoList);
                jsonResponse.Data = catpagoDTOList;
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
        public JsonResponse GetAllFilters(CVN_CATEGORIA_PAGODTO catpagoDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var tarifario = MapperHelper.Map<CVN_CATEGORIA_PAGODTO, CVN_CATEGORIA_PAGO>(catpagoDTO);

                var catpagoList = CVN_CATEGORIA_PAGOBL.Instancia.GetAllFilters(tarifario);
                var catpagoDTOList = MapperHelper.Map<IEnumerable<CVN_CATEGORIA_PAGO>, IEnumerable<CVN_CATEGORIA_PAGODTO>>(catpagoList);
                jsonResponse.Data = catpagoDTOList;
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
