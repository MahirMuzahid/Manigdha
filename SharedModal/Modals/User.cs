using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.Modals
{
    public class User
    { 
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsEmailVerified { get; set; } = false;
        public bool IsPhoneVerified { get; set; } = false;
        public string? ImageUrl { get; set;} = string.Empty;
        public string? NIDNumber { get; set; } = string.Empty;
        public string? StreetAddressOne { get; set; } = string.Empty;
        public string? StreetAddressTwo { get; set; } = string.Empty;

        [ForeignKey("City")]
        public int CityID { get; set; }
        public City? City { get; set; }

        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }




    }
}
