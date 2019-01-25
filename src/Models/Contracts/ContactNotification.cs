using System.ComponentModel.DataAnnotations;

namespace PayloadPost.Models
{
    public class ContactNotification
    {
        [Required(ErrorMessage = "É preciso colocar o nome")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do nome é de 50 caracteres.")]
        public string CostumerName { get; set; }

        [Required(ErrorMessage = "É preciso colocar um e-mail válido")]
        [EmailAddress(ErrorMessage = "Coloque um e-mail válido")]
        public string CostumerEmail { get; set; }

        [Required(ErrorMessage = "É preciso colocar um e-mail válido")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "É preciso colocar uma mensagem")]
        [StringLength(255, ErrorMessage = "O tamanho máximo da mensagem é de 255 caracteres.")]
        public string Message { get; set; }

        [Required(ErrorMessage = "É preciso colocar o nome da empresa")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do nome é de 50 caracteres.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "É preciso colocar um e-mail válido")]
        [EmailAddress(ErrorMessage = "Coloque um e-mail válido")]
        public string CompanyEmail { get; set; }
    }
}
