using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Communcation
{
    public class Request<T> : IRequest<T> where T:new()
    {
        private RestClient client;
        public Request(string baseUrl) {
            client = new RestClient(baseUrl);
            client.Timeout = 1000 * 60 * 60;
        }

        public T Get(string resourceUrl)
        {

            var request = new RestRequest(resourceUrl, Method.GET);

            IRestResponse<T> response = client.Execute<T>(request);

            return response.Data;
        }

        public Task<T> GetAsync(string resourceUrl)
        {
            var tcs = new TaskCompletionSource<T>();
            var request = new RestRequest(resourceUrl, Method.GET);
            
            client.ExecuteAsync<T>(request, response =>
            {
                tcs.SetResult(response.Data);
            });
            return tcs.Task;  
        }

        public T PostAsJson(string resourceUrl, object obj)
        {
            var request = new RestRequest(resourceUrl, Method.POST);

            string jsonToSend = JsonConvert.SerializeObject(obj);

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;          

            IRestResponse<T> response = client.Execute<T>(request);

            return response.Data;
        }

        public Task<T> PostAsJsonAsync(string resourceUrl, object obj)
        {
            var tcs = new TaskCompletionSource<T>();
            var request = new RestRequest(resourceUrl, Method.POST);

            string jsonToSend = JsonConvert.SerializeObject(obj);

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            List<T> result = new List<T>();
            client.ExecuteAsync<T>(request, response =>
            {
                tcs.SetResult(response.Data);
            });
            
            return tcs.Task;
        }

        //private static List<T> RosolveResponse<T>(IRestResponse response)
        //{
        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        RestResult<T> ret = JsonConvert.DeserializeObject <RestResult<T>>(response.Content);

        //        if (ret.ReturnCode == "0")
        //        {
        //            return ret.Data.ToList();
        //        }
        //    }
        //    return new List<T>();
        //}
    }
}
