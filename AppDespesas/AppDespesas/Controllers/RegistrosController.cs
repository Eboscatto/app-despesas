using AppDespesas.Models;
using AppDespesas.Services;
using Microsoft.AspNetCore.Mvc;
using AppDespesas.Models.ViewModels;

namespace AppDespesas.Controllers
{
    public class RegistrosController : Controller
    {
        private readonly RegistrosService _registroService;
        private readonly DespesaService _despesaService;

        public RegistrosController(RegistrosService registroService, DespesaService despesaService)
        {
            _registroService = registroService;
            _despesaService = despesaService;
        }

        public IActionResult Index()
        {
            var list = _registroService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var despesas = _despesaService.FindAll();
            var viewModel = new RegistroFormViewModel { Despesas = despesas };
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RegistroDespesas registroDespesas)
        {
            _registroService.Insert(registroDespesas);//Executa a ação
            return RedirectToAction(nameof(Index));//Retorna para página de resitros
        }

        public IActionResult Delete(int? id)//Método do delete Get
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _registroService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _registroService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)//Método do details Get
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _registroService.FindById(id.Value);
                
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
