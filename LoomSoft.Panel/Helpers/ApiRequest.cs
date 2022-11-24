using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.Helpers
{
    public class ApiRequest<T> where T : class
    {
        public static IReturnData<T> SendRequest(string path, string data, string methodType)
        {
            string apiLink = "http://loomsoft.com.tr:1313/api/";
            string responceData = string.Empty;
            try
            {
                WebRequest req;
                if (methodType == "POST")
                {
                    req = WebRequest.Create(apiLink + path);
                    req.Method = "POST";

                    req.ContentType = "application/json";
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                    using (var writer = new StreamWriter(req.GetRequestStream()))
                    {
                        writer.Write(data);
                    }
                }
                else
                {
                    req = WebRequest.Create(path + "?" + data);
                    req.Method = "GET";

                }
                WebResponse rsp = req.GetResponse();
                var strm = rsp.GetResponseStream();
                var rdr = new StreamReader(strm);
                responceData = rdr.ReadToEnd();

                return JsonConvert.DeserializeObject<IReturnData<T>>(responceData);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
