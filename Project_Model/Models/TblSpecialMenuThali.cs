namespace Project_Model.Models
{
    public class TblSpecialMenuThali
    {
        public int ThaliId { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public decimal Discount { get; set; }
    }

    public class CreateDtoSpeciaMenuThali
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public decimal Discount { get; set; }
        public List<ThaliItemDto> Items { get; set; }

    }

    public class UpdateDtoSpeciaMenuThali
    {
        public int ThaliId { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public decimal Discount { get; set; }
    }
    public class ThaliItemDto
    {
        public int ItemId { get; set; }

        public int Quantity { get; set; }
    }

    public class ResponseSpecialThaliDto
    {
        public int ThaliId { get; set; }

        public string Title { get; set; }

        public decimal Amount { get; set; }

        public decimal Discount { get; set; }

        public List<string> Items { get; set; }
        public DateTime Date { get; set; }
    }
}
