using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDespesas.Controllers
{
    public class DespesasRegistrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PesquisaSimples()
        {
            return View();
        }

        public IActionResult PesquisaGrupo()
        {
            return View();
        }
    }
}
