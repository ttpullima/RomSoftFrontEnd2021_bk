using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Business.Logic.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CON_CENTRO_COSTO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CON_CENTRO_COSTO;
using Romsoft.GESTIONCLINICA.WebApi.Core;
using Romsoft.GESTIONCLINICA.Common;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Romsoft.GESTIONCLINICA.DTO.AutoMapper;

namespace Romsoft.GESTIONCLINICA.WebApi.Controllers
{
    public class CON_CENTRO_COSTOController : BaseController
    {
        //Obtiene Lista tipo precio
        [HttpPost]
        public JsonResponse GetAllActives(CON_CENTRO_COSTODTO susaludDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var ccosto = MapperHelper.Map<CON_CENTRO_COSTODTO, CON_CENTRO_COSTO>(susaludDTO);

                var ccostoList = CON_CENTRO_COSTOBL.Instancia.GetAllActives();
                var ccostoDTOList = MapperHelper.Map<IEnumerable<CON_CENTRO_COSTO>, IEnumerable<CON_CENTRO_COSTODTO>>(ccostoList);
                jsonResponse.Data = ccostoDTOList;
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
