using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTiffinSystem.Models
{
    public class TblItem
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        [ForeignKey("Category")]
        public int Category { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool IsVegeterian { get; set; }
    }
}
