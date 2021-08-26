using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Business.Logic.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CON_CUENTA_CONTABLE;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CON_CUENTA_CONTABLE;
using Romsoft.GESTIONCLINICA.WebApi.Core;
using Romsoft.GESTIONCLINICA.Common;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Romsoft.GESTIONCLINICA.DTO.AutoMapper;

namespace Romsoft.GESTIONCLINICA.WebApi.Controllers
{
    public class CON_CUENTA_CONTABLEController : BaseController
    {
        //Obtiene Lista tipo precio
        [HttpPost]
        public JsonResponse GetAllActives(CON_CUENTA_CONTABLEDTO ctaContableDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var ctaContable = MapperHelper.Map<CON_CUENTA_CONTABLEDTO, CON_CUENTA_CONTABLE>(ctaContableDTO);

                var ctaContableList = CON_CUENTA_CONTABLEBL.Instancia.GetAllActives();
                var ctaContableDTOList = MapperHelper.Map<IEnumerable<CON_CUENTA_CONTABLE>, IEnumerable<CON_CUENTA_CONTABLEDTO>>(ctaContableList);
                jsonResponse.Data = ctaContableDTOList;
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
