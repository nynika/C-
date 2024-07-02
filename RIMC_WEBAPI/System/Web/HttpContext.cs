using Microsoft.AspNetCore.Http;

namespace System.Web
{
    internal class HttpContext
  
    {
        public static HttpContext Current { get; set; }
        public HttpRequest Request { get; }

    }
}