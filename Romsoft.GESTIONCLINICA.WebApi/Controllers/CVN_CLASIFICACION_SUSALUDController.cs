using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Business.Logic.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CVN_CLASIFICACION_SUSALUD;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_CLASIFICACION_SUSALUD;
using Romsoft.GESTIONCLINICA.WebApi.Core;
using Romsoft.GESTIONCLINICA.Common;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Romsoft.GESTIONCLINICA.DTO.AutoMapper;

namespace Romsoft.GESTIONCLINICA.WebApi.Controllers
{
    public class CVN_CLASIFICACION_SUSALUDController : BaseController
    {
        //Obtiene Lista de estados
        [HttpPost]
        public JsonResponse GetAllActives(CVN_CLASIFICACION_SUSALUDDTO susaludDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var susalud = MapperHelper.Map<CVN_CLASIFICACION_SUSALUDDTO, CVN_CLASIFICACION_SUSALUD>(susaludDTO);

                var susaludList = CVN_CLASIFICACION_SUSALUDBL.Instancia.GetAllActives();
                var susaludDTOList = MapperHelper.Map<IEnumerable<CVN_CLASIFICACION_SUSALUD>, IEnumerable<CVN_CLASIFICACION_SUSALUDDTO>>(susaludList);
                jsonResponse.Data = susaludDTOList;
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
