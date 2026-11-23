using System.ComponentModel.DataAnnotations;

namespace ExerciciosASPNET.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [StringLength(80, MinimumLength = 5, ErrorMessage = "Nome deve ter entre 5 e 80 caracteres.")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(500, MinimumLength = 10, ErrorMessage = "Descricao deve ter entre 10.")]
        [Required(ErrorMessage = "O Descricao é obrigatório")]
        public string Descricao { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Local deve ter entre 3 e 100 caracteres.")]
        [Required(ErrorMessage = "O Local é obrigatório")]
        public string Local { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data do evento é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataEvento { get; set; }

        [Range(1, 1000, ErrorMessage = "QuantidadeVagas deve ser entre 1 e 1000")]
        public int QuantidadeVagas { get; set; }

        public decimal ValorIngresso { get; set; }
    }
}