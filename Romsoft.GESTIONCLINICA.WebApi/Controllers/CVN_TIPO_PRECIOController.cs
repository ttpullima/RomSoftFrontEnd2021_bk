using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Business.Logic.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.CVN_TIPO_PRECIO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_TIPO_PRECIO;
using Romsoft.GESTIONCLINICA.WebApi.Core;
using Romsoft.GESTIONCLINICA.Common;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Romsoft.GESTIONCLINICA.DTO.AutoMapper;

namespace Romsoft.GESTIONCLINICA.WebApi.Controllers
{
    public class CVN_TIPO_PRECIOController : BaseController
    {
        //Obtiene Lista tipo precio
        [HttpPost]
        public JsonResponse GetAllActives(CVN_TIPO_PRECIODTO susaludDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var precio = MapperHelper.Map<CVN_TIPO_PRECIODTO, CVN_TIPO_PRECIO>(susaludDTO);

                var precioList = CVN_TIPO_PRECIOBL.Instancia.GetAllActives();
                var precioDTOList = MapperHelper.Map<IEnumerable<CVN_TIPO_PRECIO>, IEnumerable<CVN_TIPO_PRECIODTO>>(precioList);
                jsonResponse.Data = precioDTOList;
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
