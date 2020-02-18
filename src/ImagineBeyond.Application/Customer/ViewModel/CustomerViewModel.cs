using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace ImagineBeyond.Application.Customer.ViewModel
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [MinLength(2, ErrorMessage = "O tamanho minimo do Nome � {1}")]
        [MaxLength(150, ErrorMessage = "O tamanho m�ximo do Nome � {1}")]
        public string FirstName { get; set; }

        [MinLength(2, ErrorMessage = "O tamanho minimo do Nome � {1}")]
        [MaxLength(150, ErrorMessage = "O tamanho m�ximo do Nome � {1}")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O e-mail � requerido")]
        [EmailAddress(ErrorMessage = "E-mail em formato inv�lido")]
        public string Email { get; set; }

        public DateTime DateOfBird { get; set; }

        [JsonIgnore]
        public virtual bool OperacaoEhValida { get; set; }
    }
}