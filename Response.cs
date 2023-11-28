using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace HttpExecutor
{
    internal class Response
    {
        public static HttpResponseMessage response;

        public int statusCode() 
        {
            return Convert.ToInt32(response.StatusCode);
        }
        public string headers()
        {
            string h = "";
            h += response.Headers;
            h += response.Content.Headers;
            return h;
        }
        public string content()
        {
            var contents = response.Content.ReadAsByteArrayAsync().Result;
            string finalcontent = Encoding.UTF8.GetString(contents);

            if (finalcontent != null && finalcontent != "")
            {
                return finalcontent;
            }

            return " ";
        }
    }
}
