using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SharedModal.DTO;
using System.Security.Claims;
using System.Security.Cryptography;

namespace UserService.Service
{
    public class Mutation
    {
        private readonly IMapper _map;
        public Mutation( ClaimsPrincipal claimsPrincipal, IMapper map)
        {
            _map = map;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
       
    }
}
