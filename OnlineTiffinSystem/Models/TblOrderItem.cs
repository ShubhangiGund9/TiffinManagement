using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTiffinSystem.Models
{
    public class TblOrderItem
    {
        public int OrderItemId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Customer")]
        public int Customer { get; set; }

        [ForeignKey("Item")]
        public int Item { get; set; }
    }
}
