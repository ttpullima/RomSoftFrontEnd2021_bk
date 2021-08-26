using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Common;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Romsoft.GESTIONCLINICA.Presentacion.ApiService
{
    public class InvokeHelper
    {
        public static JsonResponse MakeRequest(string requestUrl,
            object JSONRequest,
            string JSONMethod)
        {
            try
            {
                HttpWebResponse response = null;
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                WebRequest WR = WebRequest.Create(requestUrl);
                string sb = JsonConvert.SerializeObject(JSONRequest);
                request.Timeout = Timeout.Infinite;
                request.KeepAlive = true;
                request.Method = JSONMethod;
                request.ContentType = "application/json";
                Byte[] bt = Encoding.UTF8.GetBytes(sb);
                Stream st = request.GetRequestStream();
                st.Write(bt, 0, bt.Length);
                st.Close();
                response = request.GetResponse() as HttpWebResponse;
                Stream s = response.GetResponseStream();
                StreamReader sr = new StreamReader(s);
                string stringBuffer = sr.ReadToEnd();
                return (JsonResponse)JsonConvert.DeserializeObject(stringBuffer, (new JsonResponse()).GetType());
            }
            catch (WebException wex)
            {
                HttpWebResponse httpResponse = (HttpWebResponse)(wex.Response);
                Stream s = httpResponse.GetResponseStream();
                StreamReader sr = new StreamReader(s);
                string stringBuffer = sr.ReadToEnd();
                JsonResponse jsonResponse = new JsonResponse { Success = false, Message = stringBuffer };
                return jsonResponse;
            }
        }
    }
}
