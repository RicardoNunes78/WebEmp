using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebEmp.Models;

namespace WebEmp.Controllers
{
    public class HomeController : Controller
    {
        private IPessoaBLL pessoaBll;
        public HomeController(IPessoaBLL _pessoaBll)
        {
            pessoaBll = _pessoaBll;
        }

        // GET
        public IActionResult Index()
        {
            //PessoaBLL _pessoa = new PessoaBLL();
            List<Pessoa> pessoas = pessoaBll.GetPessoas().ToList();
            return View("Lista", pessoas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pessoa pessoa)
        {
            //if (String.IsNullOrEmpty(pessoa.Nome))
            //    ModelState.AddModelError("Nome", "O Nome é obrigatório.");

            //if (String.IsNullOrEmpty(pessoa.Sexo))
            //    ModelState.AddModelError("Sexo", "O Sexo é obrigatório.");

            //if (String.IsNullOrEmpty(pessoa.Sexo))
            //    ModelState.AddModelError("Email", "O E-mail é obrigatório.");

            //if (pessoa.Nascimento <= DateTime.Now.AddYears(-18))
            //    ModelState.AddModelError("Nascimento", "Cadastro proibido para menores de idade.");

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                //PessoaBLL _pessoa = new PessoaBLL();
                pessoaBll.IncluirPessoa(pessoa);
                return RedirectToAction("Index");
            }

            //if(pessoa?.Nome == null || pessoa?.Sexo == null || pessoa?.Email == null || pessoa?.Nascimento == null)
            //{
            //    ViewBag.Erro = "Preencha todos os campos.";
            //    return View();
            //}
            //else
            //{
            //    PessoaBLL _pessoa = new PessoaBLL();
            //    _pessoa.IncluirPessoa(pessoa);
            //    return RedirectToAction("Index");
            //}
        }

        //Get para edição
        public IActionResult Edit(int id)
        {
            //PessoaBLL pessoaBLL = new PessoaBLL();
            Pessoa pessoa = pessoaBll.GetPessoas().Single(x => x.Id == id);
            return View(pessoa);
        }

        //Post da edição
        [HttpPost]
        public IActionResult Edit([Bind(nameof(Pessoa.Id),nameof(Pessoa.Sexo),nameof(Pessoa.Email),nameof(Pessoa.Nascimento))]Pessoa pessoa)
        {
            //PessoaBLL pessoaBLL = new PessoaBLL();
            pessoa.Nome = pessoaBll.GetPessoas().Single(a => a.Id == pessoa.Id).Nome;

            if(ModelState.IsValid)
            {
                /////PessoaBLL pessoaBLL = new PessoaBLL();
                pessoaBll.AtualizarPessoa(pessoa);
                return RedirectToAction("index");
            }
            return View(pessoa);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
