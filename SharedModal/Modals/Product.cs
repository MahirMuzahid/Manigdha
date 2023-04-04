using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.Modals
{
    public class Product
    {
        public int ProductID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? AskingPrice { get; set; }
        public DateTime DateAdded { get; set; }= DateTime.Now;
        public DateTime LastUpdate { get; set; }
        public string? BaseImageUrl { get; set; }
        public decimal? TopBid { get; set; }
        public bool IsActive { get; set; } = true;

        [ForeignKey("User")]
        public int UserID { get; set;}
        public User? User { get; set; }


        [ForeignKey("CatagoryType")]
        public int CatagoryTypeID { get; set; }
        public CatagoryType? CatagoryType { get; set; }
    }
}
