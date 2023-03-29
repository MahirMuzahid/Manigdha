using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using SharedModal.DTO;
using SharedModal.Modals;
using SharedModal.ReponseModal;
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Security.Cryptography;

namespace UserService.Service
{
    public class Mutation
    {
        private readonly IMapper _map;
        private IUserLoginService _userLoginService;
        public Mutation( ClaimsPrincipal claimsPrincipal, IMapper map, IUserLoginService userLoginService)
        {
            _map = map;
            _userLoginService = userLoginService;
        }
        public async Task<SharedModal.Modals.User> Register([Service] DataContext _context, UserDTO userDTO)
        {
            var obj = _map.Map<SharedModal.Modals.User>(userDTO);
            try
            {
                var userRegService = new UserRegistrationService();
                var result = userRegService.Register(obj);
                _context.Users?.Add(result);
                await _context.SaveChangesAsync();
                return (result);

            }
            catch (Exception ex)
            {
                throw new GraphQLException(ex.InnerException.Message);

            }
        }
        
        public async Task<Response> Login ([Service] DataContext _context, UserLoginDTO userLoginDTO)
        {
            var user =  _context.Users?.Where(x => (x.Email == userLoginDTO.LoginInfo || x.PhoneNumber == userLoginDTO.LoginInfo) && x.Password == userLoginDTO.Password).Select(x => new SharedModal.Modals.User
            {
                UserID = x.UserID,
                Password = x.Password,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Name = x.Name,
                PasswordHash = x.PasswordHash,
                PasswordSalt = x.PasswordSalt
            }).FirstOrDefault();
            if (user != null)
            {             
                var result = _userLoginService.Login(user);
                var userForRefreshToken = await _context.Users.FirstOrDefaultAsync(u => u.UserID == user.UserID);
                userForRefreshToken.RefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
                userForRefreshToken.TokenCreated = DateTime.Now;
                userForRefreshToken.TokenExpires = DateTime.Now.AddDays(7);
                _context.Users.Update(userForRefreshToken);
                await _context.SaveChangesAsync();
                result.ReturnStringThree= userForRefreshToken.RefreshToken.ToString();
                return result;
            }

            return new Response("User Not Found",  System.Net.HttpStatusCode.NotFound);
           
        }

        public async Task<Response> DeleteUser([Service] DataContext _context, int userID)
        {
            if (userID < 1)
            {
                return new Response("User doesn't exits", System.Net.HttpStatusCode.NotFound);

            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserID == userID);

            if (user == null) { return new Response("User doesn't exits", System.Net.HttpStatusCode.NotFound); }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return new Response("User Deleted ", System.Net.HttpStatusCode.OK);
        }

        public async Task<Response> RefreshToken ([Service] DataContext _context, int userID, string refreshToken)
        {
            if (userID < 1 || refreshToken == null)
            {
                return new Response("User doesn't exits", System.Net.HttpStatusCode.NotFound);
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserID == userID);
            if (user == null) { return new Response("User doesn't exits", System.Net.HttpStatusCode.NotFound); }

            var result = _userLoginService.RefreshToken(user, refreshToken);
            if (result.Status != System.Net.HttpStatusCode.OK) { return result; }

            user.RefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            user.TokenCreated = DateTime.Now;
            user.TokenExpires = DateTime.Now.AddDays(7);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new Response("Token Refreshed ", System.Net.HttpStatusCode.OK, user.RefreshToken, result.ReturnString);
        }

        public async Task<Response> Logout([Service] DataContext _context, int userID)
        {
            if (userID < 1)
            {
                return new Response("User doesn't exits", System.Net.HttpStatusCode.NotFound);
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserID == userID);
            if (user == null) { return new Response("User doesn't exits", System.Net.HttpStatusCode.NotFound); }

            user.RefreshToken = "";
            user.TokenCreated = new DateTime();
            user.TokenExpires= new DateTime();

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new Response( System.Net.HttpStatusCode.OK);
        }
    }
}
