using Microsoft.IdentityModel.Tokens;
using SharedModal.DTO;
using SharedModal.Modals;
using SharedModal.ReponseModal;
using System.Security.Cryptography;

namespace UserService.Service
{
    public class UserRegistrationService
    {
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public SharedModal.Modals.User Register( SharedModal.Modals.User user )
        {           
            try
            {
                if(!user.Password.IsNullOrEmpty() && !user.Password.IsNullOrEmpty())
                {
                    CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    user.RefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
                    user.TokenCreated = DateTime.Now;
                    user.TokenExpires = DateTime.Now.AddDays(7);
                }
                else
                {
                    throw new GraphQLException("Password can't be empty");
                }
                
            }
            catch (Exception ex)
            {
                throw new GraphQLException(ex.Message);

            }

            return user;

        }

   
    }
}
