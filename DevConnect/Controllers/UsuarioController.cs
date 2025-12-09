using System.Threading.Tasks;
using DevConnect.Contexts;
using DevConnect.Models;
using Microsoft.AspNetCore.Mvc;


namespace DevConnect.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DevConnectContext _context;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger, DevConnectContext context)
        {
            _logger = logger;
            _context = context;
        }

       [HttpGet]
        public IActionResult Index()
        {
             ViewBag.UsuarioNovoCadastrado = "";
              TempData["UsuarioNovoCadastrado"] = "";
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(IFormCollection form)
        {

            // Console.WriteLine($"{form["NomeCompleto"]}");
            // Console.WriteLine($"{form.Files[0].FileName}");

            TbUsuario novoUsuario = new TbUsuario
            {
                NomeCompleto = form["NomeCompleto"].ToString(),
                NomeDeUsuario = form["NomeDeUsuario"].ToString(),
                Email = form["Email"].ToString(),
                Senha = form["Senha"].ToString()
            };

            if (form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(folder, file.FileName);

                using(var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                novoUsuario.FotoPerfilUrl = file.FileName;
            }

              else
                {
                novoUsuario.FotoPerfilUrl = "";
                }

                try
                {
                    _context.TbUsuario.Add(novoUsuario);


                   await _context.SaveChangesAsync();
                    ViewBag.UsuarioNovoCadastrado = "";
                    TempData["UsuarioNovoCadastrado"] = "Cadastrado";

                    return RedirectToAction("Index", "Home");
                }
                catch (System.Exception)
                {
                    ViewBag.UsuarioNovoCadastrado = "Nao cadastrato";
                    TempData["UsuarioNovoCadastrado"] = "";
                //Vamos pedir para a view falar ao usuário que não foi cadastro
                 return View();

                }
            
        }
        public IActionResult Perfil()
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