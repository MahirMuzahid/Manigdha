using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModal.Modals
{
    public class ClothsRequirmentVerification
    {
        public int Id { get; set; }
        public bool IsTears { get;set; }
        public string? TearsPlace { get; set; }
        public string? FabricType { get; set; }
        public string? Size { get; set; }
        public string? SizeType { get; set;}
        public string? SizeTypeType { get;set; }
        public DateTime BuyingTime { get; set; }
        public bool IsReceiptAvailable { get; set; }
        public string ManOrWomen { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product? Product { get; set; }
    }
}
