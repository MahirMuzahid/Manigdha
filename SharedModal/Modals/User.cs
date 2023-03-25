﻿using System;
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
        public bool IsEmailVerified { get; set; }
        public bool IsPhoneVerified { get; set; }
        public string? ImageUrl { get; set;}
        public string? NIDNumber { get; set;}
        public string? StreetAddressOne { get; set; }
        public string? StreetAddressTwo { get; set; }

        [ForeignKey("City")]
        public City? City { get; set; }


    }
}