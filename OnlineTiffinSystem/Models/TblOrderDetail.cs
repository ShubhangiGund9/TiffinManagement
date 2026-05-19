using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTiffinSystem.Models
{
    public class TblOrderDetail
    {
        public int OrderDetailId { get; set; }

        [ForeignKey("Customer")]
        public int Customer { get; set; }

        public string OrderStatus { get; set; }

        public string PinCode { get; set; }

        public string DeliveryAddress { get; set; }

        public DateTime OrderAt { get; set; }

        public DateTime DeliveryAt { get; set; }

        public decimal TotalAmount { get; set; }

        public string Landmark { get; set; }

        public decimal ExtraCharges { get; set; }

        public float Discount { get; set; }

        [ForeignKey("DeliveryCharges")]
        public int Charge { get; set; }
    }
}

