namespace Project_Model.Models
{
    public class TblDeliveryCharges
    {
        public int ChargeId { get; set; }

        public string ChargesFor { get; set; }

        public decimal Charges { get; set; }
    }

    public class CreateDeliveryCharges
    {

        public string ChargesFor { get; set; }

        public decimal Charges { get; set; }
    }

    public class UpdateDeliveryCharges
    {
        public int ChargeId { get; set; }

        public string ChargesFor { get; set; }

        public decimal Charges { get; set; }
    }
}
