using AutoMapper;
using Azure;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using SharedModal.DTO;
using SharedModal.Modals;
using SharedModal.ReponseModal;
using System.Data;
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
        public Mutation( IMapper map, IUserLoginService userLoginService)
        {
            _map = map;
            _userLoginService = userLoginService;
        }

        #region User
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

            return new Response("User Not Found");
        }
#if DEBUG

#else
[Authorize(Roles = new string[] { "Admin" })]
#endif

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
#if DEBUG

#else
[Authorize(Roles = new string[] { "User" })]
#endif
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
#if DEBUG

#else
[Authorize(Roles = new string[] { "User" })]
#endif

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

        public async Task<Response> UpdateUser([Service ] DataContext _context, UserUpdateDTO userDTO)
        {
            var updatedObj = _map.Map<SharedModal.Modals.User>(userDTO);

            if (updatedObj.UserID == 0) { return new Response(System.Net.HttpStatusCode.NotFound); }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserID == updatedObj.UserID);

            if (user == null) { return new Response(System.Net.HttpStatusCode.NotFound); }


            if (!updatedObj.NIDNumber.IsNullOrEmpty()) 
            {
                user.NIDNumber = updatedObj.NIDNumber;
            }

            if (!updatedObj.ImageUrl.IsNullOrEmpty())
            {
                user.ImageUrl = updatedObj.ImageUrl;
            }

            if (!updatedObj.Name.IsNullOrEmpty())
            {
                user.Name = updatedObj.Name;
            }

            if (!updatedObj.Password.IsNullOrEmpty())
            {
                user.Password = updatedObj.Password;
            }

            if (!updatedObj.Email.IsNullOrEmpty())
            {
                user.Email = updatedObj.Email;
            }

            if (!updatedObj.PhoneNumber.IsNullOrEmpty())
            {
                user.PhoneNumber = updatedObj.PhoneNumber;
            }

            if (!updatedObj.StreetAddressOne.IsNullOrEmpty())
            {
                user.StreetAddressOne = updatedObj.StreetAddressOne;
            }

            if (!updatedObj.StreetAddressTwo.IsNullOrEmpty())
            {
                user.StreetAddressTwo = updatedObj.StreetAddressTwo;
            }
            _context.Users.Update(user);
            _context.SaveChanges();

            return new Response(System.Net.HttpStatusCode.OK);
        }
        #endregion

        #region City
        
#if DEBUG

#else
[Authorize(Roles = new string[] { "Admin" })]
#endif
        public async Task<Response> SetCity([Service] DataContext _context, string name, int divisionID)
        {
            if(name == null || divisionID == 0) { return new Response(System.Net.HttpStatusCode.NotFound); }
            var city = new City { Name = name , DivisionID = divisionID};
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

            return new Response(System.Net.HttpStatusCode.OK);
        }
#if DEBUG

#else
[Authorize(Roles = new string[] { "Admin" })]
#endif
        public async Task<Response> UpdateCity([Service] DataContext _context, int cityID, string name, int divisionID)
        {
            if (cityID == 0) { return new Response(System.Net.HttpStatusCode.NotFound); }

            var result = await _context.Cities.FirstOrDefaultAsync(u => u.CityID == cityID);

            if (result == null) { return new Response(System.Net.HttpStatusCode.NotFound); }

            if (!name.IsNullOrEmpty())
            {
                result.Name = name;
            }

            if (divisionID != 0)
            {
                result.DivisionID = divisionID;
            }

            _context.Cities.Update(result);
            await _context.SaveChangesAsync();

            return new Response(System.Net.HttpStatusCode.OK);
        }
#if DEBUG

#else
[Authorize(Roles = new string[] { "Admin" })]
#endif
        public async Task<Response> DeleteCity([Service] DataContext _context, int cityID)
        {
            if (cityID == 0) { return new Response(System.Net.HttpStatusCode.NotFound); }
            var result = await _context.Cities.FirstOrDefaultAsync(u => u.CityID == cityID);
            if (result == null) { return new Response(System.Net.HttpStatusCode.NotFound); }
            _context.Cities.Remove(result);
            await _context.SaveChangesAsync();

            return new Response(System.Net.HttpStatusCode.OK);
        }

        #endregion

        #region Division

#if DEBUG

#else
[Authorize(Roles = new string[] { "Admin" })]
#endif
        public async Task<Response> SetDivision([Service] DataContext _context, string name)
        {
            if (name == null) { return new Response(System.Net.HttpStatusCode.NotFound); }
            var division = new Division { DivisionName = name };
            _context.Divisions.Add(division);
            await _context.SaveChangesAsync();

            return new Response(System.Net.HttpStatusCode.OK);
        }
#if DEBUG

#else
[Authorize(Roles = new string[] { "Admin" })]
#endif
        public async Task<Response> UpdateDivision([Service] DataContext _context, string name, int divisionID)
        {
            if (name.IsNullOrEmpty() || divisionID == 0) { return new Response(System.Net.HttpStatusCode.NotFound); }

            var result = await _context.Divisions.FirstOrDefaultAsync(u => u.DivisionID == divisionID);

            if (result == null) { return new Response(System.Net.HttpStatusCode.NotFound); }

            if (!name.IsNullOrEmpty())
            {
                result.DivisionName = name;
            }

            _context.Divisions.Update(result);
            await _context.SaveChangesAsync();

            return new Response(System.Net.HttpStatusCode.OK);
        }
#if DEBUG

#else
[Authorize(Roles = new string[] { "Admin" })]
#endif
        public async Task<Response> DeleteDivision([Service] DataContext _context, int divisionID)
        {
            if (divisionID == 0) { return new Response(System.Net.HttpStatusCode.NotFound); }
            var result = await _context.Divisions.FirstOrDefaultAsync(u => u.DivisionID == divisionID);
            if (result == null) { return new Response(System.Net.HttpStatusCode.NotFound); }
            _context.Divisions.Remove(result);
            await _context.SaveChangesAsync();

            return new Response(System.Net.HttpStatusCode.OK);
        }

        #endregion



    }

}
