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

namespace SharedModal.ClientServerConnection
{
    public class UserServerConnection : IUserServerConnection
    {
        public async Task<(int, byte[] , byte[] , string , HttpStatusCode )> RegisterAndGetUser(string query, HttpClient client)
        {
            if (query == null || client == null) { return (0, new byte[0], new byte[0], string.Empty,0); }


            var content = new StringContent(JsonConvert.SerializeObject(new { query }), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/graphql", content);
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<SharedModal.Modals.User>(JObject.Parse(JObject.Parse(await response.Content.ReadAsStringAsync())["data"].ToString())["register"].ToString());
            if(result == null)
            {
                return (0, new byte[0], new byte[0], string.Empty, response.StatusCode);
            }

            return (result :result.UserID, PasswordHash: result.PasswordHash, PasswordSalt: result.PasswordSalt, RefreshToken: result.RefreshToken, StatusCode: response.StatusCode);
        }

        public async Task<(int , string , byte[] , byte[] , string , DateTime , DateTime )> RegisterAndGetUser(string query)
        {
            if (query == null) { return (0, string.Empty, new byte[0], new byte[0], string.Empty , DateTime.Now,DateTime.Now); }

            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(new { query }), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/graphql", content);
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<SharedModal.Modals.User>(JObject.Parse(JObject.Parse(await response.Content.ReadAsStringAsync())["data"].ToString())["register"].ToString());
            if (result == null)
            {
                return (0, string.Empty, new byte[0], new byte[0], string.Empty, DateTime.Now, DateTime.Now);
            }

            return (result.UserID, Password: result.Password, PasswordHash: result.PasswordHash, 
                PasswordSalt:result.PasswordSalt, RefreshToken:result.RefreshToken, TokenCreated: result.TokenCreated, TokenExpires:result.TokenExpires);
        }

       
    }
}
