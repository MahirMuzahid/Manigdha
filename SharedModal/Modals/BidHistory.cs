using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.Modals
{
    public class BidHistory
    {
        public int BidHistoryID { get; set; }
        public DateTime? BidTime { get; set; } = DateTime.Now;
        public decimal BidAmount { get; set; } = 0;

        [ForeignKey("Product")]
        public int? ProductID { get; set; }
        public Product? Product { get; set; }

        [ForeignKey("User")]
        public int? UserID { get; set; }
        public User? User { get; set; }

    }
}
