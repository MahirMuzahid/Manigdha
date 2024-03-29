﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.Modals
{
    public class City
    {
        public int CityID { get; set; }
        public string? Name { get; set; }


        [ForeignKey("Division")]
        public int? DivisionID { get; set; }
        public Division? Division { get; set; }
    }
}
