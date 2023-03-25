using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.Modals
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public DateTime? PaymentTime { get; set; } = DateTime.Now;
        public decimal PaymentAmount { get; set; } = 0;

        [ForeignKey("PaymentType")]
        public int PaymentTypeID { get; set; }
        public PaymentType? PaymentType { get; set; }

        [ForeignKey("Product")]
        public int? ProductID { get; set; }
        public Product? Product { get; set; }

        [ForeignKey("User")]
        public int? UserID { get; set; }
        public User? User { get; set; }
    }
}
