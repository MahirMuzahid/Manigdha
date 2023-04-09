using System;
using System.Collections.Generic;
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
        public static bool ShouldGoOTPView { get; set; }
        public static bool IsUserLoggedIn { get; set; }

        public static async Task GetAuthInfo()
        {
            JWTToken = await SecureStorage.Default.GetAsync(nameof(JWTToken));
        }

        public static bool IsInternetConnected()
        {
            ShowSnakeBar showSnakeBar = new ShowSnakeBar();
            NetworkAccess accessType = Connectivity.Current.NetworkAccess;
            if(accessType != NetworkAccess.Internet) { showSnakeBar.Show("No Internet Connection", SharedModal.Enums.SnakeBarType.Type.Danger, SharedModal.Enums.SnakeBarType.Time.LongTime); return false; }

            return true;
        }
        public bool IsTokenExpired(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var exp = jwtToken.Payload.Exp;
            var expirationTime = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(exp));

            return expirationTime <= DateTimeOffset.UtcNow;
        }
    }
}
