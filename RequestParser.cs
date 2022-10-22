using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
namespace HttpExecutor
{
    internal class RequestParser
    {
        private string[,] rawRequest;
        private string rawStringRequest;
        private HttpClient httpClient;
        public static string sResponse = "";
        string[] split1;
        
        public RequestParser(String raw_Request)
        {
            rawStringRequest = raw_Request;
            split1 = raw_Request.Split("\n");
            rawRequest = new string[Array.IndexOf(split1, String.Empty), 2];
            rawRequest[0, 0] = split1[0].Split(" ")[0];
            rawRequest[0, 1] = split1[0].Split(" ")[1];

            for (int i = 1; i < split1.Length; i++)
            {
                if (split1[i] == String.Empty)
                {
                    break;
                }
                for (int k = 0; k < 2; k++)
                {
                    rawRequest[i, k] = split1[i].Split(": ")[k];
                }

            }
            httpClient = new HttpClient();
        }

        public HttpResponseMessage parse()
        {

            HttpRequestMessage hrm = new HttpRequestMessage();
            httpClient.BaseAddress = uri();
            hrm.Method = method();
            hrm.Content = httpContent();

            for (int i = 1; i < rawRequest.GetLength(0); i++)
            {

                hrm.Headers.TryAddWithoutValidation(rawRequest[i, 0], rawRequest[i, 1]);
            }
            return httpClient.Send(hrm);
        }
        private Uri uri()
        {
            string url = rawRequest[0, 1];
            string dir1 = "";
            if (url.Contains("//"))
            {
                string dir = url.Substring(url.IndexOf("//") + 2);
                dir1 = dir.Substring(dir.IndexOf('/'));

            }
            else
            {
                dir1 = url.Substring(url.IndexOf('/'));
            }
            

            return new Uri("https://"+rawRequest[1, 1]  + dir1);   
        }
        private HttpMethod method()
        {
            string method = rawRequest[0, 0];
            HttpMethod h = new HttpMethod(method);
            return h;
        }
        private StringContent httpContent()
        {

            int cont = Array.IndexOf(split1, String.Empty) + 1;
            string content = "";
            for (int i = cont; i < split1.Length; i++)
            {
                content = content + "\n" + split1[i];
            }
            return new StringContent(content);
        }

        public String response(HttpResponseMessage hrm)
        {
            string response = "";
            response += "HTTP/" + hrm.Version + " " + Convert.ToInt32(hrm.StatusCode) + " " + hrm.ReasonPhrase;
            response += "\n" + hrm.Headers + hrm.Content.Headers;
            response += "\n" + hrm.Content.ReadAsStringAsync().Result;
            sResponse = response;
            return response;
        }
    }
}
