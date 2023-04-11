using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SharedModal.ReponseModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Manigdha.Model;

namespace Manigdha.GraphQL_Execution
{
    public static class RefreshTokenOnExpired
    {   
        public static async Task<bool> RefreshTokenNow()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(StaticInfo.UserServiceBaseAddress);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticInfo.JWTToken);
            var query = "mutation {\r\n\trefreshToken(refreshToken: \"" + StaticInfo.RefreshToken + "\", userID: " + StaticInfo.LoginUserID + ") {\r\n\t\tmessage\r\n\t\treturnString\r\n\t\treturnStringFour\r\n\t\treturnStringThree\r\n\t\treturnStringTwo\r\n\t\tstatus\r\n\t}\r\n}";
            var content = new StringContent(JsonConvert.SerializeObject(new { query }), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/graphql", content);
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<Response>(JObject.Parse(JObject.Parse(await response.Content.ReadAsStringAsync())["data"].ToString())["refreshToken"].ToString());

            if(result.Status != System.Net.HttpStatusCode.OK) { return false; }
            await SecureStorage.Default.SetAsync(nameof(StaticInfo.JWTToken), result.ReturnStringTwo);
            await SecureStorage.Default.SetAsync(nameof(StaticInfo.RefreshToken), result.ReturnString);
            return true;
        }
    }
}
