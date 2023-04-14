using SharedModal.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.DTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double? AskingPrice { get; set; }
        public int CatagoryTypeID { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
