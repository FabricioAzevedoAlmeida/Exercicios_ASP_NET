using Microsoft.AspNetCore.Mvc;
using ExerciciosASPNET.Models;
using ExerciciosASPNET.ViewModels;

namespace ExerciciosASPNET.Controllers
{
    public class EventosController : Controller
    {
          private static List<Evento> _evento = new()
        {
        new Evento { Id = 1,
        Nome = "Workshop de C# e .NET",
        Descricao = "Curso de C#", 
        Local = "Auditório Principal - Bloco A",
        DataEvento = new DateTime(2026, 12, 10),
        QuantidadeVagas = 50,
        ValorIngresso = 45.00m},

        new Evento {  Id = 2,
        Nome = "Feira de Tecnologia e Inovação",
        Descricao = "Feira de Tech", 
        Local = "Ginásio Poliesportivo",
        DataEvento = new DateTime(2026, 12, 15),
        QuantidadeVagas = 500,
        ValorIngresso = 0.00m},

        new Evento {  Id = 3,
        Nome = "Hackathon de Inteligência Artificial",
        Descricao = "Maratona de IA",
        Local = "Laboratório de Informática 3",
        DataEvento = new DateTime(2027, 01, 20),
        QuantidadeVagas = 120,
        ValorIngresso = 150.50m},
        };

        public IActionResult Index()
        {
            return View(_evento);
        }

        // GET /Alunos/Criar - retornar a View de Criação de Alunos
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        // POST /Alunos/Criar - recebe dados da View Criar()
        [HttpPost]
        public IActionResult Criar(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return View(evento); // retornar para a View de cadastro com erros de validação
            }


            evento.Id = _evento.Any() ? _evento.Max(a => a.Id) + 1 : 1;

            _evento.Add(evento);

            return RedirectToAction("Index");
        }
         [HttpGet]
        public IActionResult Buscar()
        {
            var viewModel = new BuscaEventoViewModel
            {
                Resultados = _evento
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Buscar(BuscaEventoViewModel model)
        {

             var query = _evento.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.NomeBusca))
            {
                query = query.Where(e => e.Nome != null && 
                    e.Nome.Contains(model.NomeBusca, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(model.LocalBusca))
            {
                query = query.Where(e => e.Local != null && 
                    e.Local.Contains(model.LocalBusca, StringComparison.OrdinalIgnoreCase));
            }

            if (model.DataInicial.HasValue)
            {
                query = query.Where(e => e.DataEvento.Date >= model.DataInicial.Value.Date);
            }
            
            if (!string.IsNullOrWhiteSpace(model.NomeBusca))
            {
                query = query.Where(e => e.Nome != null && 
                    e.Nome.Contains(model.NomeBusca, StringComparison.OrdinalIgnoreCase));
            }

            model.Resultados = query.ToList();

            return View(model);
        }

        

    }
}