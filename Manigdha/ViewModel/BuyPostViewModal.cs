using CommunityToolkit.Mvvm.ComponentModel;
using Manigdha.GraphQL_Execution;
using Manigdha.Model;
using SharedModal.ClientServerConnection.City_Server_Connection;
using SharedModal.ClientServerConnection;
using SharedModal.Modals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SharedModal.ReponseModal;
using System.Net;
using System.Net.Http.Headers;

namespace Manigdha.ViewModel
{
    public partial class BuyPostViewModal : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<int> cList;
        private ProfileViewModalQuery profileViewModalQuery;
        public BuyPostViewModal()
        {         
            CURDCall<City> curd = new CURDCall<City>();
            UserServerConnection userServerConnection = new UserServerConnection();
            CityServerConnection cityServerConnection = new CityServerConnection(curd);
            profileViewModalQuery = new ProfileViewModalQuery(userServerConnection, cityServerConnection);
            cList = new ObservableCollection<int>();
            cList.Add(0);
            cList.Add(1);
            cList.Add(2);
            cList.Add(3);
            cList.Add(4);
            GetInitInfo();
        }
        public async Task GetInitInfo()
        {
            await StaticInfo.GetAuthInfo();
            if (StaticInfo.IsJwtTokenExpired())
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(StaticInfo.UserServiceBaseAddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticInfo.JWTToken);
                var query = "mutation {\r\n\trefreshToken(refreshToken: \"" + StaticInfo.RefreshToken + "\", userID: " + StaticInfo.LoginUserID + ") {\r\n\t\tmessage\r\n\t\treturnString\r\n\t\treturnStringFour\r\n\t\treturnStringThree\r\n\t\treturnStringTwo\r\n\t\tstatus\r\n\t}\r\n}";
                var content = new StringContent(JsonConvert.SerializeObject(new { query }), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/graphql", content);
                response.EnsureSuccessStatusCode();
                var result = JsonConvert.DeserializeObject<Response>(JObject.Parse(JObject.Parse(await response.Content.ReadAsStringAsync())["data"].ToString())["refreshToken"].ToString());
            }
        }

       
    }
}
