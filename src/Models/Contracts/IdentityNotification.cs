namespace PayloadPost.Models
{
    public class IdentityNotification
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string Link { get; set; }
        public IdentityNotificationTypeEnum IdentityNotificationType { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyContactLink { get; set; }
    }
}
