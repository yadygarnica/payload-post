using System.ComponentModel.DataAnnotations;

namespace PayloadPost.Models
{
    public class PaymentNotification
    {
        [Required(ErrorMessage = "É preciso colocar o nome da empresa")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do nome é de 50 caracteres.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "É preciso colocar um e-mail válido")]
        [EmailAddress(ErrorMessage = "Coloque um e-mail válido")]
        public string CompanyEmail { get; set; }

        [Required(ErrorMessage = "É preciso colocar o nome")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do nome é de 50 caracteres.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "É preciso colocar um e-mail válido")]
        [EmailAddress(ErrorMessage = "Coloque um e-mail válido")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "É preciso colocar o tipo de notificação")]
        public PaymentNotificationTypeEnum PaymentNotificationType { get; set; }

        [Required(ErrorMessage = "É preciso colocar o valor do pagamento em centavos")]
        public long AmountInCents { get; set; }

        public string BoletoLink { get; set; }

        public string RefusedPaymentReason { get; set; }
    }
}
