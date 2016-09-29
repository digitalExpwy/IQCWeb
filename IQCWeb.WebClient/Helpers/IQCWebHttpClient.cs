using IQCWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace IQCWeb.WebClient.Helpers
{
    public static class IQCWebHttpClient
    {

        public static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(IQCWebConstants.IQCWebAPI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

          

            return client;
        }
    }
}