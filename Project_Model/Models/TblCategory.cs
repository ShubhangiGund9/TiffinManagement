namespace Project_Model.Models
{
    public class TblCategory
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class CreateDtoCategory
    {

        public string CategoryName { get; set; }
    }

    public class UpdateDtoCategory
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
