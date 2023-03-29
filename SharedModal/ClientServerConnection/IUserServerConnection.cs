using SharedModal.DTO;
using SharedModal.Modals;
using SharedModal.ReponseModal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.ClientServerConnection
{
    public interface IUserServerConnection
    {
        public Task<(int UserID, byte[] PasswordHash, byte[] PasswordSalt, string RefreshToken, HttpStatusCode ResponseCode)> RegisterAndGetUser( HttpClient client,string query);
        public Task<(int UserID, string Password, byte[] PasswordHash, byte[] PasswordSalt, string RefreshToken, DateTime TokenCreated, DateTime TokenExpires)> RegisterAndGetUser(string query);
        public Task<Response> DeleteUser(HttpClient client, string query, string queryName);

        public Task<Response> LoginUser(HttpClient client, string query, string queryName);


    }
}
