using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Model.Models
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

        public float Tax { get; set; }
        public virtual TblCategory Categories{ get; set; } = null!;

        public string ItemPhoto { get; set; }

    }

    public class CreateDtoItem
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        [ForeignKey("Category")]
        public int Category { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool IsVegeterian { get; set; }
        public float Tax { get; set; }
        public string ItemPhoto { get; set; }


    }

    public class UpdateDtoItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Category { get; set; }
        public decimal Price { get; set; }
        = 0;
        public string Description { get; set; }
        public bool IsVegeterian { get; set; }
        public float Tax { get; set; }
        public string ItemPhoto { get; set; }




    }
    public class ResponseItemDto
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Category { get; set; }

        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public float Tax { get; set; }

        public bool IsVegeterian { get; set; }
        public string ItemPhoto { get; set; }

    }
}
