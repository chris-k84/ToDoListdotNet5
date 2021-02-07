using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WpfToDoList
{
    class ApiHelper
    {
        public static HttpClient httpClient { get; set; }

        public static void InitialiseClient()
        {
            httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri("http://xkcd.com/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
