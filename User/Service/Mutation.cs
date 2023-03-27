using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SharedModal.DTO;
using SharedModal.Modals;
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
        public async Task<SharedModal.Modals.User> Register([Service] DataContext _context, UserDTO studentDto)
        {
            var obj = _map.Map<SharedModal.Modals.User>(studentDto);
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
            return new SharedModal.ReponseModal.Response("User Not Found", 404);

           
        }

        public SharedModal.Modals.User test ([Service] DataContext _context, string a)
        {
            return new SharedModal.Modals.User() { Name = a};
        }






    }
}
