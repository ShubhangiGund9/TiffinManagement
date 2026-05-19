namespace OnlineTiffinSystem.Models
{
    public class TblCustomer
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string EmailAddress { get; set; }

        public string CustomerAddress { get; set; }

        public string MobileNo { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
