using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppDespesas.Models;

namespace AppDespesas.Controllers
{
    public class RegistroDespesasController : Controller
    {
        private readonly AppDespesasContext _context;

        public RegistroDespesasController(AppDespesasContext context)
        {
            _context = context;
        }

        // GET: RegistroDespesas
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegistrosDespesas.ToListAsync());
        }

        // GET: RegistroDespesas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroDespesas = await _context.RegistrosDespesas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroDespesas == null)
            {
                return NotFound();
            }

            return View(registroDespesas);
        }

        // GET: RegistroDespesas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistroDespesas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Historico,Valor,Pagamento")] RegistroDespesas registroDespesas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroDespesas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registroDespesas);
        }

        // GET: RegistroDespesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroDespesas = await _context.RegistrosDespesas.FindAsync(id);
            if (registroDespesas == null)
            {
                return NotFound();
            }
            return View(registroDespesas);
        }

        // POST: RegistroDespesas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Historico,Valor,Pagamento")] RegistroDespesas registroDespesas)
        {
            if (id != registroDespesas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroDespesas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroDespesasExists(registroDespesas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registroDespesas);
        }

        // GET: RegistroDespesas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroDespesas = await _context.RegistrosDespesas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroDespesas == null)
            {
                return NotFound();
            }

            return View(registroDespesas);
        }

        // POST: RegistroDespesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroDespesas = await _context.RegistrosDespesas.FindAsync(id);
            _context.RegistrosDespesas.Remove(registroDespesas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroDespesasExists(int id)
        {
            return _context.RegistrosDespesas.Any(e => e.Id == id);
        }
    }
}
