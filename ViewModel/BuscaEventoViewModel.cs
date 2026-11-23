
using ExerciciosASPNET.Models;

namespace ExerciciosASPNET.ViewModels
{
    public class BuscaEventoViewModel
    {
        public string? TermoBusca { get; set; }
        public List<Evento> Resultados { get; set; } = new();
    }
}