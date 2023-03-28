﻿using SharedModal.DTO;
using SharedModal.Modals;
using SharedModal.ReponseModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.ClientServerConnection
{
    public interface IUserServerConnection
    {
        public Task<(int UserID, byte[] PasswordHsh, byte[] PasswordSault, string RefreshToken, HttpStatusCode ResponseCode)> RegisterAndGetUser(string query, HttpClient client);
        public Task<(int UserID, string Password, byte[] PasswordHsh, byte[] PasswordSault, string RefreshToken, DateTime TokenCreated, DateTime TokenExpires)> RegisterAndGetUser(string query);
    }
}
