using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
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
        
        public SharedModal.ReponseModal.Response Login ([Service] DataContext _context, UserLoginDTO userLoginDTO)
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
                return result;
            }
            return new SharedModal.ReponseModal.Response("User Not Found",  System.Net.HttpStatusCode.NotFound);
           
        }

        public async SharedModal.ReponseModal.Response DeleteUser([Service] DataContext _context, int userID)
        {
            if (userID > 0)
            {
                var user = await _context.Users.Include(u => u.City).FirstOrDefaultAsync(u => u.UserID == userID);
                if (user == null) { return new SharedModal.ReponseModal.Response("User doen't exits", System.Net.HttpStatusCode.NotFound); }
                _context.Users.Remove(user);
                return new SharedModal.ReponseModal.Response("User Deleted ", System.Net.HttpStatusCode.OK);
            }
        }
    }
}
