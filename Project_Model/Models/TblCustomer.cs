namespace Project_Model.Models
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
        public string Id { get; set; }
    }
    public class CreateDtoCustomer
    {
        public string CustomerName { get; set; }
        public string EmailAddress { get; set; }
        public string CustomerAddress { get; set; }

        public string MobileNo { get; set; }

        public string Password { get; set; }
        public string Id { get; set; }

    }

    public class UpdateDtoCustomer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string EmailAddress { get; set; }
        public string CustomerAddress { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public string Id { get; set; }

    }
}
