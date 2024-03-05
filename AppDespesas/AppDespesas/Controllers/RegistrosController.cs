﻿using AppDespesas.Models;
using AppDespesas.Services;
using Microsoft.AspNetCore.Mvc;
using AppDespesas.Models.ViewModels;
using System.Collections.Generic;
using AppDespesas.Services.Exceptions;

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

        public IActionResult Details(int? id)//Método Get do details 
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
        //Ação Edit do método GET
        public IActionResult Edit(int? id)
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
            //Abre a tela de edição
            List<Despesa> despeas = _despesaService.FindAll();
            RegistroFormViewModel viewModel = new RegistroFormViewModel { RegistroDespesas = obj, Despesas = despeas };
            return View(viewModel);
        }
        //Ação Edit do método POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RegistroDespesas registroDespesas)
        {
            if (id != registroDespesas.Id)
            {
                return BadRequest();
            }
           try
            {
                _registroService.Update(registroDespesas);
                return RedirectToAction(nameof(Index));
            }
            catch(KeyNotFoundException e)
            {
                return NotFound();
            }

            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }

    }
}
