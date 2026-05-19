using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTiffinSystem.Models
{
    public class TblMenuthaliItem
    {
        public int ThaliItemId { get; set; }

        [ForeignKey("SpecialMenuThali")]
        public int Thali { get; set; }

        [ForeignKey("Item")]
        public int Item { get; set; }

        public int Quantity { get; set; }
    }

    public class CreateDtoMenuThaliItem
    {
        public int Thali { get; set; }

        public int Item { get; set; }

        public int Quantity { get; set; }
    }
}
