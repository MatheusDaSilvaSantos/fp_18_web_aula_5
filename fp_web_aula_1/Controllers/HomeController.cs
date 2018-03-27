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

        public HomeController(ILogerApi log,INoticiaService noticiaService)
        {
            _log = log;
            _noticiaService = noticiaService;
        }
        public IActionResult Index()
        {
            //fakeTotalMiliseconds = 2;
            _log.Log(Request.HttpContext, TotalTime);
            _noticiaService.List();

            ViewBag.Mensagem = "Hello";
            ViewData["Mensagem2"] = "Hello2";

            return View();
        }

        //public string Index()
        //{
        //    return "Hello Fiap";
        //}
    }
}
