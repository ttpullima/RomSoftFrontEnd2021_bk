using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Business.Logic.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CVN_CATEGORIA_PAGO_PRECIO;
using Romsoft.GESTIONCLINICA.Entidades;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_CATEGORIA_PAGO_PRECIO;
using Romsoft.GESTIONCLINICA.WebApi.Core;
using Romsoft.GESTIONCLINICA.Common;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Romsoft.GESTIONCLINICA.DTO.AutoMapper;

namespace Romsoft.GESTIONCLINICA.WebApi.Controllers
{
    public class CVN_CATEGORIA_PAGO_PRECIOController : BaseController
    {
        [HttpPost]
        public JsonResponse Add(CVN_CATEGORIA_PAGO_PRECIODTO pagoprecioDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                int resultado = 0;
                var pagoprecio = MapperHelper.Map<CVN_CATEGORIA_PAGO_PRECIODTO, CVN_CATEGORIA_PAGO_PRECIO>(pagoprecioDTO);

                if (!CVN_CATEGORIA_PAGO_PRECIOBL.Instancia.Exists(pagoprecio))
                {
                    resultado = CVN_CATEGORIA_PAGO_PRECIOBL.Instancia.Add(pagoprecio);

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
                    Usuario = pagoprecioDTO.UsuarioCreacion,
                    Objeto = JsonConvert.SerializeObject(pagoprecioDTO)
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
                    Usuario = pagoprecioDTO.UsuarioCreacion,
                    Objeto = JsonConvert.SerializeObject(pagoprecioDTO)
                });
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse Delete(CVN_CATEGORIA_PAGO_PRECIODTO pagoprecioDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                var participante = MapperHelper.Map<CVN_CATEGORIA_PAGO_PRECIODTO, CVN_CATEGORIA_PAGO_PRECIO>(pagoprecioDTO);
                int resultado = CVN_CATEGORIA_PAGO_PRECIOBL.Instancia.Delete(participante);

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
                    Usuario = pagoprecioDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(pagoprecioDTO)
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
                    Usuario = pagoprecioDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(pagoprecioDTO)
                });
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse GetAllActivesFilters(CVN_CATEGORIA_PAGO_PRECIODTO pagoprecioDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var pagoprecio = MapperHelper.Map<CVN_CATEGORIA_PAGO_PRECIODTO, CVN_CATEGORIA_PAGO_PRECIO>(pagoprecioDTO);

                var pagoprecioList = CVN_CATEGORIA_PAGO_PRECIOBL.Instancia.GetAllActivesFilters(pagoprecio);
                var pagoprecioListDTOList = MapperHelper.Map<IEnumerable<CVN_CATEGORIA_PAGO_PRECIO>, IEnumerable<CVN_CATEGORIA_PAGO_PRECIODTO>>(pagoprecioList);
                jsonResponse.Data = pagoprecioListDTOList;
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
