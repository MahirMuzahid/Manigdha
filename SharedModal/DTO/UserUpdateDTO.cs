using SharedModal.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.DTO
{
    public class UserUpdateDTO
    {
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public string? NIDNumber { get; set; } = string.Empty;
        public string? StreetAddressOne { get; set; } = string.Empty;
        public string? StreetAddressTwo { get; set; } = string.Empty;
        public int CityID { get; set; }
    }

}
