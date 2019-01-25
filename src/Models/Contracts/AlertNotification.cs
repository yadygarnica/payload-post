using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PayloadPost.Models
{
    public class AlertNotification
    {

        [Required(ErrorMessage = "É preciso colocar o nome da empresa")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do nome é de 50 caracteres.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "É preciso colocar um e-mail válido")]
        [EmailAddress(ErrorMessage = "Coloque um e-mail válido")]
        public string CompanyEmail { get; set; }

        [Required]
        public IEnumerable<Keeper> Keepers { get; set; }

        [Required]
        public string AffectedSystem { get; set; }

        [Required]
        public string ErrorDetail { get; set; }

        [Required]
        public DateTime OccurrenceDateTime { get; set; }

        public string TicketLink { get; set; }
    }
}
