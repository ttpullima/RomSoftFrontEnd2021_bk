using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romsoft.GESTIONCLINICA.Common
{
    public class JsonResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public bool Warning { get; set; }
        public object Data { get; set; }
    }
}
