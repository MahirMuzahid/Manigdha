using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manigdha
{
    public class StaticInfo
    {
        public static int LoginUserID { get ; set ; }
        public static string JWTToken { get; set; }
        public static string RefreshToken { get; set; }
        public static string UserServiceBaseAddress = "https://manigdhapi.azurewebsites.net/graphql";
        public static bool ShouldGoOTPView { get; set; }
    }
}
