using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTiffinSystem.Models
{
    public class TblPayment
    {
        public int PaymentId { get; set; }

        [ForeignKey("OrderDetail")]
        public int OrderDetail { get; set; }

        public DateTime PaymentAt { get; set; }

        public string PatymentMode { get; set; }

        public string PaymentDescription { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
