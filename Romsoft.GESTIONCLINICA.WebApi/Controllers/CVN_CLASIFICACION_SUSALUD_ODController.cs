using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Business.Logic.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CVN_CLASIFICACION_SUSALUD_OD;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_CLASIFICACION_SUSALUD_OD;
using Romsoft.GESTIONCLINICA.WebApi.Core;
using Romsoft.GESTIONCLINICA.Common;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Romsoft.GESTIONCLINICA.DTO.AutoMapper;

namespace Romsoft.GESTIONCLINICA.WebApi.Controllers
{
    public class CVN_CLASIFICACION_SUSALUD_ODController : BaseController
    {
        //Obtiene Lista de susalud od
        [HttpPost]
        public JsonResponse GetAllActives(CVN_CLASIFICACION_SUSALUD_ODDTO susaludDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var susalud_od = MapperHelper.Map<CVN_CLASIFICACION_SUSALUD_ODDTO, CVN_CLASIFICACION_SUSALUD_OD>(susaludDTO);

                var susalud_odList = CVN_CLASIFICACION_SUSALUD_ODBL.Instancia.GetAllActives();
                var susalud_odDTOList = MapperHelper.Map<IEnumerable<CVN_CLASIFICACION_SUSALUD_OD>, IEnumerable<CVN_CLASIFICACION_SUSALUD_ODDTO>>(susalud_odList);
                jsonResponse.Data = susalud_odDTOList;
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
