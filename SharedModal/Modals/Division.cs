using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.Modals
{
    public class Division
    {
        public int DivisionID { get; set; }
        public string? DivisionName { get; set; }
        public ICollection<City>? Cities { get; set; }
    }
}
