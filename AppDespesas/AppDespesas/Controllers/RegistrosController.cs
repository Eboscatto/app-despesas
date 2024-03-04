using AppDespesas.Models;
using AppDespesas.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDespesas.Controllers
{
    public class RegistrosController : Controller
    {
        private readonly RegistroService _registroService;

        public RegistrosController(RegistroService registroService)
        {
            _registroService = registroService;
        }

        public IActionResult Index()
        {
            var list = _registroService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RegistroDespesas registro)
        {
            _registroService.Insert(registro);//Executa a ação
            return RedirectToAction(nameof(Index));//Retorna para página de resitros
        }
    }
}
