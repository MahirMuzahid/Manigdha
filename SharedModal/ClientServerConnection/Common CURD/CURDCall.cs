using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SharedModal.Modals;
using SharedModal.ReponseModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.ClientServerConnection
{
    public class CURDCall<T>: ICURDCall<T> where T : class
    {
        public async Task<List<T>> Get(HttpClient client, string query, string queryName)
        {
            var response = await GetQueryResponse(client, query);
            if (response.StatusCode == HttpStatusCode.NotFound) { return new List<T>(); }
            var result = JsonConvert.DeserializeObject<List<T>>(JObject.Parse(JObject.Parse(await response.Content.ReadAsStringAsync())["data"].ToString())[queryName].ToString());
            if (result == null)
            {
                return new List<T>();
            }
            return result;
        }

        public async Task<T> GetWithID(HttpClient client, string query, string queryName)
        {
            var response = await GetQueryResponse(client, query);
            if (response.StatusCode == HttpStatusCode.NotFound) { return default!; }
            var queryString = JObject.Parse(JObject.Parse(await response.Content.ReadAsStringAsync())["data"].ToString())[queryName].ToString();
            var result = JsonConvert.DeserializeObject<T>(queryString);
            if (result == null)
            {
                return default!;
            }
            return result;
        }

        public async Task<List<T>> GetWithIDList(HttpClient client, string query, string queryName)
        {
            var response = await GetQueryResponse(client, query);
            if (response.StatusCode == HttpStatusCode.NotFound) { return default!; }
            var queryString = JObject.Parse(JObject.Parse(await response.Content.ReadAsStringAsync())["data"].ToString())[queryName].ToString();
            var result = JsonConvert.DeserializeObject<List<T>>(queryString);
            if (result == null)
            {
                return default!;
            }
            return result;
        }

        public async Task<Response> Set(HttpClient client, string query, string queryName)
        {
            var response = await GetQueryResponse(client, query);
            if (response.StatusCode == HttpStatusCode.NotFound) { return new Response(HttpStatusCode.NotFound); }
            var queryString = JObject.Parse(JObject.Parse(await response.Content.ReadAsStringAsync())["data"].ToString())[queryName].ToString();
            var result = JsonConvert.DeserializeObject<Response>(queryString);
            if (result == null)
            {
                return new Response(HttpStatusCode.NotFound);
            }
            return result;
        }
        public async Task<Response> Update(HttpClient client, string query, string queryName)
        {
            var response = await GetQueryResponse(client, query);
            if (response.StatusCode == HttpStatusCode.NotFound) { return new Response(HttpStatusCode.NotFound); }
            var queryString = JObject.Parse(JObject.Parse(await response.Content.ReadAsStringAsync())["data"].ToString())[queryName].ToString();
            var result = JsonConvert.DeserializeObject<Response>(queryString);
            if (result == null)
            {
                return new Response(HttpStatusCode.NotFound);
            }
            return result;
        }
        public async Task<Response> Delete(HttpClient client, string query, string queryName)
        {
            var response = await GetQueryResponse(client, query);
            if (response.StatusCode == HttpStatusCode.NotFound) { return new Response(HttpStatusCode.NotFound); }
            var queryString = JObject.Parse(JObject.Parse(await response.Content.ReadAsStringAsync())["data"].ToString())[queryName].ToString();
            var result = JsonConvert.DeserializeObject<Response>(queryString);
            if (result == null)
            {
                return new Response(HttpStatusCode.NotFound);
            }
            return result;
        }

        public static async Task<HttpResponseMessage> GetQueryResponse(HttpClient client, string query)
        {
            if (query == null) { return new HttpResponseMessage() { StatusCode = HttpStatusCode.NotFound }; }
            var content = new StringContent(JsonConvert.SerializeObject(new { query }), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/graphql", content);
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}
