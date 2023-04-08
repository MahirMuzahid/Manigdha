using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Manigdha.Model;
using SharedModal.ClientServerConnection;
using SharedModal.ClientServerConnection.City_Server_Connection;
using SharedModal.DTO;
using SharedModal.Enums;
using SharedModal.Modals;
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
        [ObservableProperty]
        public string rName;
        [ObservableProperty]
        public string rPhoneNumber;
        [ObservableProperty]
        public string rEmail;
        [ObservableProperty]
        public string rPassword;
        [ObservableProperty]
        public string rConfirmPassword;
        [ObservableProperty]
        public string rNameErrorText;
        [ObservableProperty]
        public string rPhoneNumberErrorText;
        [ObservableProperty]
        public string rEmailErrorText;
        [ObservableProperty]
        public string rPasswordErrorText;
        [ObservableProperty]
        public string rConfirmPasswordErrorText;
        [ObservableProperty]
        public string rCityErrorText;
        [ObservableProperty]
        public List<string> cityNameList;
        [ObservableProperty]
        public string selectedCity;
        List<City> CityList = new List<City>();
        HttpClient client = new HttpClient();
        private IUserServerConnection _userserverConnection;
        private ICityServerConnectio _cityserverConnection;
        private ShowSnakeBar showSnake = new ShowSnakeBar();
        public ProfileViewModal(IUserServerConnection serverConnection, ICityServerConnectio cityServerConnectio)
        {
            
            CleanUpUI();           
            client.BaseAddress = new Uri(StaticInfo.UserServiceBaseAddress);
            _userserverConnection = serverConnection;
            _cityserverConnection = cityServerConnectio;
           
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
        public async Task GetInitData()
        {
            await GetCityData();
        }
        
        public async Task GetCityData()
        {
            try
            {
                
                CityList = await GetCities();
                CityNameList = new List<string>();
                CityNameList.Clear();
                CityNameList = CityList.Where(c => c.Name != null).Select(c => c.Name).ToList();

            }
            catch (Exception ex) 
            {
               await showSnake.Show(ex.Message, SnakeBarType.Type.Danger);
            }
            
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
            var query = "mutation {\r\n\tlogin(userLoginDTO: { loginInfo: \"" + EmailOrPhoneNumber + "\", password: \"" + Password + "\" }) {\r\n\t\tmessage\r\n\t\treturnString\r\n\t\treturnStringFour\r\n\t\treturnStringThree\r\n\t\treturnStringTwo\r\n\t\tstatus\r\n\t}\r\n}";
            return await _userserverConnection.LoginUser(client, query, "login");
        }

        [RelayCommand]
        public async Task Register()
        {
            RCityErrorText = "";
            RNameErrorText = "";
            REmailErrorText = "";
            RPhoneNumberErrorText = "";
            RPasswordErrorText = "";
            City city = CityList.FirstOrDefault(c => c.Name == SelectedCity);
            if(city == null) { RCityErrorText = "Please select city"; return;  }
            try
            {
                UserDTO userDTO = new UserDTO(RName, RPassword, REmail, RPhoneNumber, city.CityID);
            }
            catch (ArgumentException ex)
            {

                if (ex.ParamName == nameof(UserDTO.Name).ToString())
                {
                    RNameErrorText = new string(ex.Message.TakeWhile(c => c != '(').ToArray()); 
                }
                if (ex.ParamName == nameof(UserDTO.Email).ToString())
                {
                    REmailErrorText = new string(ex.Message.TakeWhile(c => c != '(').ToArray());
                }
                if (ex.ParamName == nameof(UserDTO.PhoneNumber).ToString())
                {
                    RPhoneNumberErrorText = new string(ex.Message.TakeWhile(c => c != '(').ToArray());
                }
                if (ex.ParamName == nameof(UserDTO.Password).ToString())
                {
                    RPasswordErrorText = new string(ex.Message.TakeWhile(c => c != '(').ToArray());
                }
                if (ex.ParamName == nameof(UserDTO.CityID).ToString())
                {
                    RCityErrorText = new string(ex.Message.TakeWhile(c => c != '(').ToArray());
                }

            }
            if (RPassword != RConfirmPassword) { RPasswordErrorText = "Password Doen't Match"; return; }


            await RegisterUser(city.CityID);
        }


        public async Task<Response> RegisterUser(int cityID)
        {
            var query = "mutation {\r\n\tregister(userDTO: { name: \""+RName+"\", password: \""+RPassword+"\", email: \""+REmail+"\", phoneNumber: \""+RPhoneNumber+"\", cityID: "+ cityID + " }) {\r\n\t\tuserID\r\n\t}\r\n}";
            var result = await _userserverConnection.RegisterAndGetUser(client, query);

            if(result.UserID != 0) { }

            return new Response();
        }
        public async Task<List<City>> GetCities()
        {
            var query = "query{ city() { cityID, name, divisionID, division { divisionName } } }";
            return await _cityserverConnection.GetCity(client, query, "city");
        }
    }
}