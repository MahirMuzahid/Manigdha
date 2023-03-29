using Azure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using SharedModal.ReponseModal;
using System.Security.Claims;
using System.Security.Cryptography;

namespace UserService.Service
{
    public class UserLoginService : IUserLoginService
    {
        IConfiguration _config;
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

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

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


        public SharedModal.ReponseModal.Response Login(SharedModal.Modals.User user)
        {


            if (user == null || !VerifyPasswordHash(user.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new SharedModal.ReponseModal.Response("Wrong Emai/Phonenumber/Password",  System.Net.HttpStatusCode.NotAcceptable);
            }

            string token = CreateToken(user);


            return new SharedModal.ReponseModal.Response("OK", 0, token, user.UserID.ToString());
        }

        //public async Task<Response> RefreshToken(int userID, string refreshtoken)
        //{


        //    var player = await _playerManager.GetFirstOrDefaultAsync(x => x.Id == userID);

        //    if (!player.RefreshToken.Equals(refreshtoken))
        //    {
        //        return new Response("Not Authorize", 1, "");
        //    }
        //    else if (player.TokenExpires < DateTime.Now)
        //    {
        //        return new Response("Token Expired", 2, "");
        //    }

        //    string token = CreateToken(player);
        //    return new Response("Ok", 0, token);
        //}
        //public async Task<Response> Logout(int userID)
        //{
        //    var player = await _playerManager.GetFirstOrDefaultAsync(x => x.Id == userID);
        //    player.RefreshToken = "";
        //    player.TokenCreated = DateTime.Now;
        //    player.TokenExpires = DateTime.Now;
        //    try
        //    {
        //        await _playerManager.UpdateAsync(player);
        //        return new Response("Logout Done", 0, "");
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response(ex.Message, 1, "");
        //    }
        //}
    }
}
