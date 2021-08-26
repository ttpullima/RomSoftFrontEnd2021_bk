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
    public class TIPO_ESTADOController : BaseController
    {

        //Obtiene Lista de estados
        [HttpPost]
        public JsonResponse GetAllFilters(DTO.TABLAS.TIPO_ESTADO.TIPO_ESTADODTO estadoDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var estado = MapperHelper.Map<DTO.TABLAS.TIPO_ESTADO.TIPO_ESTADODTO, Entidades.TIPO_ESTADO.TIPO_ESTADO>(estadoDTO);

                var estadoList = TIPO_ESTADOBL.Instancia.GetAllFilters(estado);
                var estadoDTOList = MapperHelper.Map<IEnumerable<Entidades.TIPO_ESTADO.TIPO_ESTADO>, IEnumerable<DTO.TABLAS.TIPO_ESTADO.TIPO_ESTADODTO>>(estadoList);
                jsonResponse.Data = estadoDTOList;
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
