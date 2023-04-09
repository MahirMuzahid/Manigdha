using SharedModal.ClientServerConnection.City_Server_Connection;
using SharedModal.ClientServerConnection;
using SharedModal.Modals;
using SharedModal.ReponseModal;
using System.Net;
using Manigdha.Model;

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
            _userserverConnection = serverConnection;
            _cityserverConnection = cityServerConnectio;

        }
        public async Task<bool> RegisterUser(int cityID, string RName, string RPassword, string REmail, string RPhoneNumber)
        {
            if (!StaticInfo.IsInternetConnected()) { return false; }
            var query = "mutation {\r\n\tregister(userDTO: { name: \"" + RName + "\", password: \"" + RPassword + "\", email: \"" + REmail + "\", phoneNumber: \"" + RPhoneNumber + "\", cityID: " + cityID + " }) {\r\n\t\tuserID\r\n\t}\r\n}";
            var result = await _userserverConnection.RegisterAndGetUser(client, query);

            if (result.UserID == 0) { return false; }
            return true;


        }
        public async Task<List<City>> GetCities()
        {
            if (!StaticInfo.IsInternetConnected()) { return new List<City>(); }
            var query = "query{ city() { cityID, name, divisionID, division { divisionName } } }";
            return await _cityserverConnection.GetCity(client, query, "city");
        }
        public async Task<Response> LoginApiExecute(string EmailOrPhoneNumber, string Password)
        {
            if (!StaticInfo.IsInternetConnected()) { return new Response(); }
            if (string.IsNullOrEmpty(EmailOrPhoneNumber) || string.IsNullOrEmpty(Password))
            {
                return new Response(HttpStatusCode.NotFound);
            }
            var query = "mutation {\r\n\tlogin(userLoginDTO: { loginInfo: \"" + EmailOrPhoneNumber + "\", password: \"" + Password + "\" }) {\r\n\t\tmessage\r\n\t\treturnString\r\n\t\treturnStringFour\r\n\t\treturnStringThree\r\n\t\treturnStringTwo\r\n\t\tstatus\r\n\t}\r\n}";
            return await _userserverConnection.LoginUser(client, query, "login");
        }
        public async Task<Response> SendOTP(int otp)
        {
            if (!StaticInfo.IsInternetConnected()) { return new Response(); }
            if (otp < 10000)
            {
                return new Response(HttpStatusCode.NotFound);
            }
            //var query = "mutation {\r\n\tlogin(userLoginDTO: { loginInfo: \"" + EmailOrPhoneNumber + "\", password: \"" + Password + "\" }) {\r\n\t\tmessage\r\n\t\treturnString\r\n\t\treturnStringFour\r\n\t\treturnStringThree\r\n\t\treturnStringTwo\r\n\t\tstatus\r\n\t}\r\n}";
            //return await _userserverConnection.LoginUser(client, query, "login");

            return new Response(HttpStatusCode.OK);
        }
    }
}
