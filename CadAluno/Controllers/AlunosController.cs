using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CadAluno.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadAluno.Controllers
{

    public class AlunosController : Controller
    {
        private readonly ILogger<AlunosController> _logger;

        public AlunosController(ILogger<AlunosController> logger)
        {
            _logger = logger;
        }

        // private static List<Aluno> aluno = new List<Aluno>
        // {
        //     new Aluno{ Id= 1, Nome = "Felipe", Idade = 17,},
        //     new Aluno{Id = 2, Nome = "Lucas", Idade = 16,},
        //     new Aluno{Id = 3, Nome = "Thiago", Idade = 17,},
        //     new Aluno{Id = 4, Nome = "Crevelaro", Idade = 17,}
        // };

        private readonly CadAlunoContext _context;

        private readonly ILogger<AlunosController> logger;

        public AlunosController (ILogger<AlunosController> logger, CadAlunoContext context)
        {
           _logger = logger;
           _context = context;
        }

        // public IActionResult Index()
        // {
        //     return View(aluno);
        // }

        public async Task<IActionResult> Create(Aluno aluno)
        {
           _context.Add(aluno);
           await _context.SaveChangesAsync();

           return RedirectToAction(nameof(Index));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // public IActionResult Create(Aluno alunos)
        // {
        //     //salvar no arreay
        //     alunos.Id = aluno.Max(a => a.Id) + 1; //cira o próximo id
        //     aluno.Add(alunos);
        //     //redireciaonar o usuário para a Indez
        //     return RedirectToAction("Index");
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}