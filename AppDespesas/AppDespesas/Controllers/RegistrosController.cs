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
    }
}
