using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Model.Models
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
    public class CreatePaymentDto
    {
        public int OrderDetail { get; set; }
        public string PatymentMode { get; set; }

        public string PaymentDescription { get; set; }

        public decimal TotalAmount { get; set; }

    }

    public class UpdatePaymentDto
    {
        public int PaymentId { get; set; }

        public int OrderDetail { get; set; }

        public string PatymentMode { get; set; }

        public string PaymentDescription { get; set; }

        public decimal TotalAmount { get; set; }
    }

    public class ResponsePaymentDto
    {
        public int PaymentId { get; set; }

        public string PatymentMode { get; set; }

        public string PaymentDescription { get; set; }

        public decimal TotalAmount { get; set; }

        public int OrderDetailId { get; set; }

        public string OrderStatus { get; set; }

        public string PinCode { get; set; }

        public string DeliveryAddress { get; set; }

        public DateTime OrderAt { get; set; }

        public DateTime DeliveryAt { get; set; }

        public string Landmark { get; set; }

        public decimal ExtraCharges { get; set; }

        public float Discount { get; set; }

        public string CustomerName { get; set; }

        public string MobileNo{ get; set; }

        public string EmailAddress { get; set; }
    }
}
