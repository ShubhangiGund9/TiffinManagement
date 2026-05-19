using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Model.Models
{
    public class TblOrderItem
    {
        public int OrderItemId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("OrderDetail")]
        public int OrderDetail { get; set; }

        [ForeignKey("Item")]
        public int Item { get; set; }
    }

    public class CreateOrderItemDto
    {
        public int Quantity { get; set; }

        public int OrderDetail { get; set; }
        public int Item { get; set; }

    }

    public class UpdateOrderItemDto
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }

        public int OrderDetail{ get; set; }
        public int Item { get; set; }

    }

    public class ResponseOrderItemDto
    {

        
            public int OrderItemId { get; set; }

            public int Quantity { get; set; }

            public int OrderDetailId { get; set; }

            public int ItemId { get; set; }

            public string ItemName { get; set; }

            public decimal Price { get; set; }

        public string Description { get; set; }
    }

}
