using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.Modals
{
    public class CatagoryType
    {
        public int CatagoryTypeID { get; set; }
        public string? Name { get; set; }


        [ForeignKey("ProductCatagory")]
        public int? ProductCatagoryID { get; set; }
        public ProductCatagory? ProductCatagory { get; set; }
    }
}
