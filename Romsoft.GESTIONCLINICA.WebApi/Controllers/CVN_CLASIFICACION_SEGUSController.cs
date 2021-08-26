using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Business.Logic.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CVN_CLASIFICACION_SEGUS;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_CLASIFICACION_SEGUS;
using Romsoft.GESTIONCLINICA.WebApi.Core;
using Romsoft.GESTIONCLINICA.Common;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Romsoft.GESTIONCLINICA.DTO.AutoMapper;

namespace Romsoft.GESTIONCLINICA.WebApi.Controllers
{
    public class CVN_CLASIFICACION_SEGUSController : BaseController
    {
        //Obtiene Lista de estados
        [HttpPost]
        public JsonResponse GetAllActives(CVN_CLASIFICACION_SEGUSDTO clasificacionDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var estado = MapperHelper.Map<CVN_CLASIFICACION_SEGUSDTO, CVN_CLASIFICACION_SEGUS>(clasificacionDTO);

                var clasificacionList = CVN_CLASIFICACION_SEGUSBL.Instancia.GetAllActives();
                var estadoDTOList = MapperHelper.Map<IEnumerable<CVN_CLASIFICACION_SEGUS>, IEnumerable<CVN_CLASIFICACION_SEGUSDTO>>(clasificacionList);
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
