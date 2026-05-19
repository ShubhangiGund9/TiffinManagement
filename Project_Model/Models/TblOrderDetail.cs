using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Model.Models
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

    public class CreateDtoOderDetail
    {


        public int Customer { get; set; }

        public string OrderStatus { get; set; }

        public string PinCode { get; set; }

        public string DeliveryAddress { get; set; }

        public decimal TotalAmount { get; set; }

        public string Landmark { get; set; }

        public decimal ExtraCharges { get; set; }

        public float Discount { get; set; }

        public int Charge { get; set; }
        public List<CartItemDto> Items { get; set; }
    }

    public class UpdateDtoOrderDetailItem
    {
        public int OrderDetailId { get; set; }

        public int Customer { get; set; }

        public string OrderStatus { get; set; }

        public string PinCode { get; set; }

        public string DeliveryAddress { get; set; }

        public decimal TotalAmount { get; set; }

        public string Landmark { get; set; }

        public decimal ExtraCharges { get; set; }

        public float Discount { get; set; }

        public int Charge { get; set; }
    }

    public class ResponseOrderDetail
    {
        public int OrderDetailId { get; set; }

        public string CustomerName { get; set; }

        public string OrderStatus { get; set; }

        public string PinCode { get; set; }

        public string DeliveryAddress { get; set; }

        public DateTime OrderAt { get; set; }

        public DateTime DeliveryAt { get; set; }

        public decimal TotalAmount { get; set; }

        public string Landmark { get; set; }

        public decimal ExtraCharges { get; set; }

        public float Discount { get; set; }

        public string ChargesFor { get; set; }
    }

    public class CartItemDto
    {
        public int ItemId { get; set; }

        public int Qty { get; set; }

        public decimal Price { get; set; }

        public decimal Tax { get; set; }
    }
}

