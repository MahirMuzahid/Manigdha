using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SharedModal.ClientServerConnection;
using SharedModal.ReponseModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Manigdha.ViewModel
{
    public partial class ProfileViewModal : ObservableObject
    {
        [ObservableProperty]
        public string emailOrPhoneNumber;
        [ObservableProperty]
        public string password;
        [ObservableProperty]
        public string testText;
        [ObservableProperty]
        public string emailOrPhoneNumberErrorText;
        [ObservableProperty]
        public string passwordErrorText;

        private IUserServerConnection _serverConnection;

        public ProfileViewModal(IUserServerConnection serverConnection)
        {
            EmailOrPhoneNumberErrorText = "";
            PasswordErrorText = "";
            _serverConnection = serverConnection;
        }

        [RelayCommand]
        public async Task Login()
        {
            var result = await LoginApiExecute();
            if (result.Status != HttpStatusCode.OK) { return; }
            StaticInfo.LoginUserID = int.Parse(result.ReturnStringTwo);
            StaticInfo.RefreshToken = result.ReturnStringThree;
        }
        
        private async Task<Response> LoginApiExecute()
        {
            if (string.IsNullOrEmpty(EmailOrPhoneNumber) || string.IsNullOrEmpty(Password)) { return new Response(HttpStatusCode.NotFound); }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(StaticInfo.UserServiceBaseAddress);
            var query = "mutation {\r\n\tlogin(userLoginDTO: { loginInfo: \""+EmailOrPhoneNumber + "\", password: \""+Password +"\" }) {\r\n\t\tmessage\r\n\t\treturnString\r\n\t\treturnStringFour\r\n\t\treturnStringThree\r\n\t\treturnStringTwo\r\n\t\tstatus\r\n\t}\r\n}";
            return await _serverConnection.LoginUser(client, query, "login");
        }
    }
}
