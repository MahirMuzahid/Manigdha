using SharedModal.ClientServerConnection.City_Server_Connection;
using SharedModal.ClientServerConnection;
using SharedModal.Modals;
using SharedModal.ReponseModal;
using System.Net;
using System.Net.Http.Headers;
using Manigdha.Model.StaticFolder;

namespace Manigdha.GraphQL_Execution
{
    public class ProfileViewModalQuery
    {
        private HttpClient client = new HttpClient();
        private IUserServerConnection _userserverConnection;
        private ICityServerConnectio _cityserverConnection;

        public ProfileViewModalQuery(IUserServerConnection serverConnection, ICityServerConnectio cityServerConnectio)
        {
            client.BaseAddress = new Uri(StaticInfo.UserServiceBaseAddress);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticInfo.JWTToken);
            _userserverConnection = serverConnection;
            _cityserverConnection = cityServerConnectio;

        }
        public async Task<bool> RegisterUser(int cityID, string RName, string RPassword, string REmail, string RPhoneNumber)
        {

            var query = "mutation {\r\n\tregister(cityID: "+cityID+", email: \""+REmail+"\", name: \""+RName+"\", password: \""+RPassword+"\", phonenumber: \""+RPhoneNumber+"\") {\r\n\t\tuserID\r\n\t}\r\n}";
            var result = await _userserverConnection.RegisterAndGetUser(client, query);
            if (result.UserID == 0) { return false; }
            return true;
        }
        public async Task<List<City>> GetCities()
        {
            var query = "query{ city() { cityID, name, divisionID, division { divisionName } } }";
            return await _cityserverConnection.GetCity(client, query, "city");
        }
        public async Task<Response> LoginApiExecute(string EmailOrPhoneNumber, string Password)
        {

            if (string.IsNullOrEmpty(EmailOrPhoneNumber) || string.IsNullOrEmpty(Password))
            {
                return new Response(HttpStatusCode.NotFound);
            }
            var query = "mutation {\r\n\tlogin(userLoginDTO: { loginInfo: \"" + EmailOrPhoneNumber + "\", password: \"" + Password + "\" }) {\r\n\t\tmessage\r\n\t\treturnString\r\n\t\treturnStringFour\r\n\t\treturnStringThree\r\n\t\treturnStringTwo\r\n\t\tstatus\r\n\t}\r\n}";
            return await _userserverConnection.LoginUser(client, query, "login");
        }
        public async Task<Response> SendOTP(int otp)
        {
            //if (!StaticInfo.IsInternetConnectedOrTokenExpired()) { return new Response(); }
            if (otp < 10000)
            {
                return new Response(HttpStatusCode.NotFound);
            }
            //var query = "mutation {\r\n\tlogin(userLoginDTO: { loginInfo: \"" + EmailOrPhoneNumber + "\", password: \"" + Password + "\" }) {\r\n\t\tmessage\r\n\t\treturnString\r\n\t\treturnStringFour\r\n\t\treturnStringThree\r\n\t\treturnStringTwo\r\n\t\tstatus\r\n\t}\r\n}";
            //return await _userserverConnection.LoginUser(client, query, "login");

            return new Response(HttpStatusCode.OK);
        }

        public async Task<Response> RefreshToken()
        {
            //if (!StaticInfo.IsInternetConnectedOrTokenExpired()) { return new Response(); }
            var query = "mutation {\r\n\trefreshToken(refreshToken: \""+ StaticInfo.RefreshToken +"\", userID: "+StaticInfo.LoginUserID+") {\r\n\t\tmessage\r\n\t\treturnString\r\n\t\treturnStringFour\r\n\t\treturnStringThree\r\n\t\treturnStringTwo\r\n\t\tstatus\r\n\t}\r\n}";
            try
            {
                return await _userserverConnection.RefreshToken(client, query, "refreshToken");
            }
            catch (Exception ex) 
            {
                return new Response(HttpStatusCode.NotFound);
            }
           
        }
    }
}
