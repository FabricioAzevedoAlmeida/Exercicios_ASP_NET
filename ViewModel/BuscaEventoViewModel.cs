
using System.ComponentModel.DataAnnotations;
using ExerciciosASPNET.Models;

namespace ExerciciosASPNET.ViewModels
{
    public class BuscaEventoViewModel
    {
        [Display(Name = "Nome do Evento")]
        public string? NomeBusca { get; set; }

        [Display(Name = "Local")]
        public string? LocalBusca { get; set; }

        [Display(Name = "A partir da Data")]
        [DataType(DataType.Date)]
        public DateTime? DataInicial { get; set; }

        public List<Evento> Resultados { get; set; } = new List<Evento>();
    }
}