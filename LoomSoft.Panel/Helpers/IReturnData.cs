using System.Net;

namespace LoomSoft.Panel.Helpers
{
    public class IReturnData
    {
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string ExMessage { get; set; }
    }
    public class IReturnData<T> where T : class
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string ExMessage { get; set; }
    }
}
