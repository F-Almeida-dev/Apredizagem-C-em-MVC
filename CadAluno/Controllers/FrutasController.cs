using CadAluno.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadAluno.Controllers
{
    public class FrutasController : Controller
    {
        private readonly ILogger<FrutasController> _logger;

        public FrutasController(ILogger<FrutasController> logger)
        {
            _logger = logger;
        }

        //Criar uma lista de Frutas
        private static List<Fruta> fruta = new List<Fruta>
        {
            new Fruta{Id = 1, Nome = "Maçã" , Cor = "Vermelha", Categoria = "Tropical"},
            new Fruta{Id = 2, Nome = "Banana" , Cor = "Amarela", Categoria = "Tropical"},
            new Fruta{Id = 3, Nome = "Laranja" , Cor = "Laranja", Categoria = "Cítrica"},
            new Fruta{Id = 4, Nome = "Abacaxi" , Cor = "Amarelo", Categoria = "Cítrica"}
        };

        public IActionResult Index()
        {
            return View(fruta);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Método para salvar uma fruta 
        [HttpPost]
        public IActionResult Cerate(Fruta frutas)
        {
            //Salvar no array 
            frutas.Id = fruta.Max(f => f.Id) + 1;
            fruta.Add(frutas);
            //Redirecionar o usuário para o Index
            return RedirectToAction("Index");
        }
        
        public IActionResult Citricas()
        {
            return View();
        }
        public IActionResult Tropicais()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}