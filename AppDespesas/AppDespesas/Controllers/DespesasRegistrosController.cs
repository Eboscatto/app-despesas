using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDespesas.Services;

namespace AppDespesas.Controllers
{
    public class DespesasRegistrosController : Controller
    {
        private readonly RegistrosDespesaService _registrosDespesaService;

        public DespesasRegistrosController(RegistrosDespesaService registrosDespesaService)
        {
            _registrosDespesaService = registrosDespesaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task <IActionResult> PesquisaSimples(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            
            //Envia data para o formulário de pesquisa
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _registrosDespesaService.FindByIdDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> PesquisaGrupo(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            //Envia data para o formulário de pesquisa
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _registrosDespesaService.FindByIdDateGrupoAsync(minDate, maxDate);
            return View(result);
        }
    }
}
