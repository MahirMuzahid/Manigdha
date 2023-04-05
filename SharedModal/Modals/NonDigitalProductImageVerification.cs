using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.Modals
{
    public class NonDigitalProductImageVerification
    {
        public int Id { get; set; }
        public string? UpperSideImageURL { get; set; }
        public string? LowerSideImageURL { get; set; }
        public string? LaftSideImageURL { get; set; }
        public string? RightSideImageURL { get; set; }
        public string? FrontSideImageURL { get; set; }
        public string? BackSideImageURL { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product? Product { get; set; }
    }
}
