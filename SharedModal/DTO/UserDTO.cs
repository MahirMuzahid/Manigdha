﻿using Ardalis.GuardClauses;
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
            PhoneNumber = Guard.Against.NullOrEmpty(phonenumber, nameof(PhoneNumber), "Please fill up Phone Number");
            PhoneNumber = Guard.Against.InvalidInput(phonenumber, nameof(PhoneNumber), s => s.Length > 10, "Enter a valid phone number");
            PhoneNumber = Guard.Against.InvalidInput(phonenumber, nameof(PhoneNumber), s => s.All(char.IsDigit), "Enter a valid phone number");
            Email = Guard.Against.NullOrEmpty(email, nameof(Email), "Please fill up email");
            Email = Guard.Against.InvalidInput(email, nameof(Email), s => s.Contains('@'), "Enter a valid email");
            Password = Guard.Against.NullOrEmpty(pass, nameof(Password), "Please fill up Password");
            Password = Guard.Against.InvalidInput(pass, nameof(Password), s => s.Length > 5, "Password Should be greater then 6 word.");
            CityID = CityID;
        }
    }
}
