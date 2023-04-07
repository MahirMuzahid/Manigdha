using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SharedModal.ClientServerConnection;
using SharedModal.ReponseModal;
using System.Net;

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

        [ObservableProperty]
        public bool isBusy;

        [ObservableProperty]
        public string loginText;

        [ObservableProperty]
        public bool isLoginBtnEnabled;

        private IUserServerConnection _serverConnection;

        public ProfileViewModal(IUserServerConnection serverConnection)
        {
            CleanUpUI();
            _serverConnection = serverConnection;
            
        }
        public void CleanUpUI()
        {
            EmailOrPhoneNumberErrorText = "";
            PasswordErrorText = "";
            IsBusy = false;
            LoginText = "Login";
            IsLoginBtnEnabled = true;
        }
        [RelayCommand]
        public async Task Login()
        {
            IsLoginBtnEnabled = false;
            LoginText = "";
            IsBusy = true;
            var result = await LoginApiExecute();
            if (result.Status != HttpStatusCode.OK)
            {
                CleanUpUI();
                EmailOrPhoneNumberErrorText = "Wrong Email / Phone Number";
                PasswordErrorText = "Wrong Password";
                return;
            }
            CleanUpUI();
            StaticInfo.LoginUserID = int.Parse(result.ReturnStringTwo);
            StaticInfo.RefreshToken = result.ReturnStringThree;
            StaticInfo.JWTToken = result.ReturnString;          
            IsLoginBtnEnabled = true;
        }

        private async Task<Response> LoginApiExecute()
        {
            if (string.IsNullOrEmpty(EmailOrPhoneNumber) || string.IsNullOrEmpty(Password))
            {               
                return new Response(HttpStatusCode.NotFound);
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(StaticInfo.UserServiceBaseAddress);
            var query = "mutation {\r\n\tlogin(userLoginDTO: { loginInfo: \"" + EmailOrPhoneNumber + "\", password: \"" + Password + "\" }) {\r\n\t\tmessage\r\n\t\treturnString\r\n\t\treturnStringFour\r\n\t\treturnStringThree\r\n\t\treturnStringTwo\r\n\t\tstatus\r\n\t}\r\n}";
            return await _serverConnection.LoginUser(client, query, "login");
        }
    }
}