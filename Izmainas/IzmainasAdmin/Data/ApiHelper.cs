using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace IzmainasAdmin.Data
{
    public class ApiHelper : IApiHelper
    {
        private HttpClient _client;

        public ApiHelper()
        {
            InitClient();
        }

        public HttpClient ApiClient
        {
            get
            {
                return _client;
            }
        }

        private void InitClient()
        {
            var api = ConfigurationManager.AppSettings["api"];
            _client = new HttpClient();
            _client.BaseAddress = new Uri(api);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
