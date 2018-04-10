using fp_18_web_aula_1_core.Services;
using fp_web_aula_1_core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace fp_web_aula_1.Controllers
{
    public class HomeController : Controller
    {
        private const int TotalTime = 2;
        private ILogerApi _log;
        private INoticiaService _noticiaService;
        private IChaveService _chaveService;

        public HomeController(ILogerApi log,INoticiaService noticiaService, IChaveService chaveService)
        {
            _log = log;
            _noticiaService = noticiaService;
            _chaveService = chaveService;
        }
        public IActionResult Index()
        {
            //fakeTotalMiliseconds = 2;
            _log.Log(Request.HttpContext, TotalTime);
            _noticiaService.List();

            ViewBag.Mensagem = "Fifa Rússia 2018";
            //ViewData["Mensagem2"] = "Hello2";

            var chaves = _chaveService.List();

            return View(chaves);
        }

        //public string Index()
        //{
        //    return "Hello Fiap";
        //}
    }
}
