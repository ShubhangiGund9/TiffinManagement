using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Model.Models
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

    public class CreateDtoMenuthaliItem
    {

        public int Thali { get; set; }

        public int Item { get; set; }

        public int Quantity { get; set; }
    }

    public class UpdateMenuthaliItem
    {
        public int ThaliItemId { get; set; }

        public int Thali { get; set; }

        public int Item { get; set; }

        public int Quantity { get; set; }
    }

    public class ResponseMenuThaliItemDto
    {
        public int ThaliItemId { get; set; }

        public string Title { get; set; }

        public string ItemName { get; set; }

        public int Quantity { get; set; }
    }
}
