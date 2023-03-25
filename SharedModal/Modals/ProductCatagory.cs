using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.Modals
{
    public class ProductCatagory
    {
        public int ProductCatagoryID { get; set; }
        public string? Name { get; set; }

        public ICollection<CatagoryType>? CatagoryTypes { get; set; }
    }
}
