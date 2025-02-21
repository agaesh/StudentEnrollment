namespace StudentEnrollment.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int UserID { get; set; }
        public double TotalPaymentCost { get; set; }
    }
}