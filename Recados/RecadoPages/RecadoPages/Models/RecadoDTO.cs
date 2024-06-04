using System.ComponentModel.DataAnnotations;

namespace RecadoPages.Models
{
    public class RecadoDTO
    {
        [Required,MaxLength(100)]
        public string Mensagem { get; set; } = "";
        [Required,MaxLength(100)]
        public string Remetente { get; set; } = "";
        [Required,MaxLength(100)]
        public string Destinatario { get; set; } = "";
    }
}

