using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharedModal.Modals;
using SharedModal.ReponseModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.ClientServerConnection.City_Server_Connection
{
    public class CityServerConnection : ICityServerConnectio
    {
        public async Task<List<City>> GetCity(HttpClient client, string query, string queryName)
        {
            var response = await GetQueryResponse(client, query);
            if (response.StatusCode == HttpStatusCode.NotFound) { return new List<City>(); }
            var result = JsonConvert.DeserializeObject<List<City>>(JObject.Parse(JObject.Parse(await response.Content.ReadAsStringAsync())["data"].ToString())[queryName].ToString());
            if (result == null)
            {
                return new List<City>();
            }
            return result;
        }

        public async Task<City> GetCityWithID(HttpClient client, string query, string queryName)
        {
            var response = await GetQueryResponse(client, query);
            if (response.StatusCode == HttpStatusCode.NotFound) { return new City(); }
            var queryString = JObject.Parse(JObject.Parse(await response.Content.ReadAsStringAsync())["data"].ToString())[queryName].ToString();
            var result = JsonConvert.DeserializeObject<City>(queryString);
            if (result == null)
            {
                return new City();
            }
            return result;
        }

        public async Task<Response> SetCity(HttpClient client, string query, string queryName)
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
