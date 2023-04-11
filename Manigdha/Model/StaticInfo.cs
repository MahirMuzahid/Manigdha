using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manigdha.Model
{
    public class StaticInfo
    {
        public static int LoginUserID { get; set; }
        public static string JWTToken { get; set; }
        public static string RefreshToken { get; set; }
        public static string UserServiceBaseAddress = "https://manigdhapi.azurewebsites.net/graphql";
        public static string PostServiceBaseAddress = "https://postserviceapi.azurewebsites.net/graphql";
        public static bool ShouldGoOTPView { get; set; }

        public static async Task GetAuthInfo()
        {
            var id = await SecureStorage.Default.GetAsync(nameof(StaticInfo.LoginUserID));
            RefreshToken = await SecureStorage.Default.GetAsync(nameof(StaticInfo.RefreshToken));
            JWTToken = await SecureStorage.Default.GetAsync(nameof(StaticInfo.JWTToken));
            LoginUserID = int.Parse(id);
        }

        public static bool IsInternetConnected()
        {
            ShowSnakeBar showSnakeBar = new ShowSnakeBar();
            NetworkAccess accessType = Connectivity.Current.NetworkAccess;
            if(accessType != NetworkAccess.Internet) { showSnakeBar.Show("No Internet Connection", SharedModal.Enums.SnakeBarType.Type.Danger, SharedModal.Enums.SnakeBarType.Time.LongTime); return false; }

            return true;
        }
        public static bool IsJwtTokenExpired()
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(JWTToken);

            var exp = token.Claims.FirstOrDefault(claim => claim.Type == "exp")?.Value;
            if (string.IsNullOrEmpty(exp))
            {
                return false;
            }

            var expDate = DateTimeOffset.FromUnixTimeSeconds(long.Parse(exp));
            var isOutDatedToken = expDate <= DateTimeOffset.Now;

            return isOutDatedToken;
        }

        public static (bool, bool) CheckNetAndJWTToken()
        {
            return (IsInternetConnected(), IsJwtTokenExpired());
        }
    }
}
