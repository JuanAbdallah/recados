using System.ComponentModel.DataAnnotations;

namespace RecadoPages.Models
{
    public class Recado
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Mensagem { get; set; } = "";
        [MaxLength(100)]
        public string Remetente { get; set; } = "";
        [MaxLength(100)]
        public string Destinatario { get; set; } = "";
    }
}
