
using DevConnect.Models;
using Microsoft.AspNetCore.Mvc;
using DevConnect.Contexts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace MvcDevConnect.Controllers
{
    public class FeedController : Controller
    {

        private readonly DevConnectContext _context;
        private readonly ILogger<FeedController> _logger;

        public FeedController(ILogger<FeedController> logger, DevConnectContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<TbPublicacao> publicacaos = await _context.TbPublicacao
                .Include(p => p.IdUsuarioNavigation)
                .ToListAsync();
                return View(publicacaos);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection form)
        {
            // Console.WriteLine($"{form["NomeCompleto"]}");
            // Console.WriteLine($"{form.Files[0].FileName}");

            TbPublicacao novaPostagem = new TbPublicacao
            {
                Descricao = form["Descricao"].ToString(),
                ImagemUrl = form["ImagemUrl"].ToString(),
                DataPublicacao = DateOnly.FromDateTime(DateTime.Now)
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

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                ;

                novaPostagem.ImagemUrl = file.FileName;

            }

            try
            {
                _context.TbPublicacao.Add(novaPostagem);

                await _context.SaveChangesAsync();
                List<TbPublicacao> publicacaos = await _context.TbPublicacao.ToListAsync();
                ViewBag.PublicacaoCadastrada = "Cadastrada";
                return View(publicacaos);

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}