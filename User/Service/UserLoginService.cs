using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace UserService.Service
{
    public class UserLoginService : IUserLoginService
    {
        private IConfiguration _config;

        public UserLoginService(IConfiguration config)
        {
            _config = config;
        }

        private string CreateToken(SharedModal.Modals.User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "User"),
                new Claim(ClaimTypes.MobilePhone , user.PhoneNumber),
                new Claim(ClaimTypes.Name, user.Name)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
#if DEBUG
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );
#else
                var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: cred
                );
#endif


            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public Response Login(SharedModal.Modals.User user)
        {
            if (user == null || !VerifyPasswordHash(user.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new Response("Wrong Emai/Phonenumber/Password", System.Net.HttpStatusCode.NotAcceptable);
            }

            string token = CreateToken(user);

            return new Response("OK", System.Net.HttpStatusCode.OK, token, user.UserID.ToString());
        }

        public Response RefreshToken(SharedModal.Modals.User user, string refreshtoken)
        {
            if (!user.RefreshToken.Equals(refreshtoken))
            {
                return new Response(System.Net.HttpStatusCode.NotFound);
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return new Response(System.Net.HttpStatusCode.RequestTimeout);
            }

            string token = CreateToken(user);
            return new Response("Ok", System.Net.HttpStatusCode.OK, token);
        }
    }
}