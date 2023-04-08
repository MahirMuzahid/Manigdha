using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Manigdha.GraphQL_Execution;
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
        private ShowSnakeBar showSnake = new ShowSnakeBar();
        private ProfileViewModalQuery profileViewModalQuery;
        public ProfileViewModal()
        {
            CURDCall<City> curd = new CURDCall<City>();
            UserServerConnection userServerConnection = new UserServerConnection();
            CityServerConnection cityServerConnection = new CityServerConnection(curd);
            profileViewModalQuery = new ProfileViewModalQuery(userServerConnection, cityServerConnection);
            CleanUpUI();           
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
                
                CityList = await profileViewModalQuery.GetCities();
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
            var result = await profileViewModalQuery.LoginApiExecute(EmailOrPhoneNumber, Password);
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


        [RelayCommand]
        public async Task Register()
        {
            RCityErrorText = "";
            RNameErrorText = "";
            REmailErrorText = "";
            RPhoneNumberErrorText = "";
            RPasswordErrorText = "";
            
            try
            {
                UserDTO userDTO = new UserDTO(RName, RPassword, REmail, RPhoneNumber, 0);
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
                return ;
            }
            if (RPassword != RConfirmPassword) { RPasswordErrorText = "Password Doen't Match"; return; }
            City city = CityList.FirstOrDefault(c => c.Name == SelectedCity);
            if (city == null) { RCityErrorText = "Please select city"; return; }

            var isRegistered = await  profileViewModalQuery.RegisterUser(city.CityID,RName,RPassword,REmail,RPhoneNumber);
        }


       
    }
}