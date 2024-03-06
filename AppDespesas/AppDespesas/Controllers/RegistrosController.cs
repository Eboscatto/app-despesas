using AppDespesas.Models;
using AppDespesas.Services;
using Microsoft.AspNetCore.Mvc;
using AppDespesas.Models.ViewModels;
using System.Collections.Generic;
using AppDespesas.Services.Exceptions;
using System.Diagnostics;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            var list = await _registroService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var despesas = await _despesaService.FindAllAsync();
            var viewModel = new RegistroFormViewModel { Despesas = despesas };
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistroDespesas registroDespesas)
        {
            //Faz a validação mesmo se o JS estiver desabilitado
            if (!ModelState.IsValid)
            {
                var despesas = await _despesaService.FindAllAsync();
                var viewModel = new RegistroFormViewModel { RegistroDespesas = registroDespesas, Despesas = despesas };
                return View(viewModel);
            }
            await _registroService.InsertAsync(registroDespesas);//Executa a ação
            return RedirectToAction(nameof(Index));//Retorna para página de resitros
        }

        public async Task<IActionResult> Delete(int? id)//Método do delete Get
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }
            var obj = await _registroService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não exite!" });
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _registroService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)//Método Get do details 
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }

            var obj = await _registroService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe!" });
            }
            return View(obj);
        }
        //Ação Edit do método GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }
            var obj = await _registroService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não confere!" });
            }
            //Abre a tela de edição
            List<Despesa> despeas = await _despesaService.FindAllAsync();
            RegistroFormViewModel viewModel = new RegistroFormViewModel { RegistroDespesas = obj, Despesas = despeas };
            return View(viewModel);
        }
        //Ação Edit do método POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RegistroDespesas registroDespesas)
        {
            if (!ModelState.IsValid)
            {
                var despesas = await _despesaService.FindAllAsync();
                var viewModel = new RegistroFormViewModel { RegistroDespesas = registroDespesas, Despesas = despesas };
                return View(viewModel);
            }

            if (id != registroDespesas.Id)
            {
                return  RedirectToAction(nameof(Error), new { message = "Id não confere!" });
            }
           try
            {
                await _registroService.UpdateAsync(registroDespesas);
                return RedirectToAction(nameof(Index));
            }
            catch(KeyNotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        //Médodo de Erros
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

    }
}
