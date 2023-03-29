using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SharedModal.DTO;
using SharedModal.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using SharedModal.ReponseModal;
using System.Collections;

namespace SharedModal.ClientServerConnection
{
    public class UserServerConnection : IUserServerConnection
    {
        public async Task<(int, byte[] , byte[] , string , HttpStatusCode )> RegisterAndGetUser( HttpClient client, string query)
        {
            if (query == null || client == null) { return (0, Array.Empty<byte>(), Array.Empty<byte>(), string.Empty,0); }


            var content = new StringContent(JsonConvert.SerializeObject(new { query }), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/graphql", content);
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<User>(JObject.Parse(JObject.Parse(await response.Content.ReadAsStringAsync())["data"].ToString())["register"].ToString());
            if(result == null)
            {
                return (0, Array.Empty<byte>(), Array.Empty<byte>(), string.Empty, response.StatusCode);
            }

            return (result :result.UserID, result.PasswordHash, result.PasswordSalt, result.RefreshToken, response.StatusCode);
        }

       

        public async Task<Response> DeleteUser(HttpClient client, string query, string queryName)
        {
            if (query == null) { return new Response("User Not Found", HttpStatusCode.NotFound); }
            var content = new StringContent(JsonConvert.SerializeObject(new { query }), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/graphql", content);
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<Response>(JObject.Parse(JObject.Parse(await response.Content.ReadAsStringAsync())["data"].ToString())[queryName].ToString());
            if (result == null)
            {
                return new Response("User Not Found", HttpStatusCode.NotFound);
            }
            return new Response("User Deleted", HttpStatusCode.OK);
        }

        public async Task<Response> LoginUser(HttpClient client, string query, string queryName)
        {
            if (query == null) { return new Response("User Not Found", HttpStatusCode.NotFound); }
            var content = new StringContent(JsonConvert.SerializeObject(new { query }), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/graphql", content);
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<Response>(JObject.Parse(JObject.Parse(await response.Content.ReadAsStringAsync())["data"].ToString())[queryName].ToString());
            if (result == null)
            {
                return new Response("User Not Found", HttpStatusCode.NotFound);
            }
            return  result;
        }

        public async Task<Response> LogoutUser(HttpClient client, string query, string queryName)
        {
            var response = await GetQueryResponse(client, query);
            if (response.StatusCode == HttpStatusCode.NotFound) { return new Response("User Not Found", HttpStatusCode.NotFound); } 
            var result = JsonConvert.DeserializeObject<Response>(JObject.Parse(JObject.Parse(await response.Content.ReadAsStringAsync())["data"].ToString())[queryName].ToString());
            if (result == null)
            {
                return new Response("User Not Found", HttpStatusCode.NotFound);
            }
            return new Response("User Loged Out", HttpStatusCode.OK);
        }
        public async Task<Response> RefreshToken(HttpClient client, string query, string queryName)
        {
            var response = await GetQueryResponse(client, query);
            if (response.StatusCode == HttpStatusCode.NotFound) { return new Response("Invalid Token", HttpStatusCode.NotFound); }
            var result = JsonConvert.DeserializeObject<Response>(JObject.Parse(JObject.Parse(await response.Content.ReadAsStringAsync())["data"].ToString())[queryName].ToString());
            if (result == null)
            {
                return new Response("User Not Found", HttpStatusCode.NotFound);
            }
            return result;
        }

        public static async Task<HttpResponseMessage> GetQueryResponse(HttpClient client, string query)
        {
            if (query == null) { return new HttpResponseMessage() {  StatusCode = HttpStatusCode.NotFound}; }
            var content = new StringContent(JsonConvert.SerializeObject(new { query }), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/graphql", content);
            response.EnsureSuccessStatusCode();
            return response;
        }

    }
}
