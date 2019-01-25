namespace PayloadPost.Models
{
    public class PaymentBoletoViewModel
    {
        public string CustomerName { get; set; }        
        public string BoletoLink { get; set; }
        public string CompanyName { get; set; }
        public string CompanyWebsite { get; set; }
        public int BoletoValidDaysCount { get; set; }
    }
}
