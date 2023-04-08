using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.DTO
{
    public class UserDTO
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int CityID { get; set; }

        public UserDTO(string name, string pass, string email, string phonenumber, int cityId)
        {
            Name = Guard.Against.NullOrEmpty(name,nameof(Name),"Please fill up name");
            Password = Guard.Against.InvalidInput(pass, nameof(Password), s => s.Length > 6, "Password Should be greater then 6 word.");
            Email = Guard.Against.NullOrEmpty(email, nameof(Email), "Please fill up email") ;
            PhoneNumber = Guard.Against.InvalidInput(phonenumber, nameof(PhoneNumber), s => s.Length > 11, "Enter a valid phone number");
            CityID = Guard.Against.NegativeOrZero(cityId, nameof(CityID), "Please select city") ;
        }
    }
}
