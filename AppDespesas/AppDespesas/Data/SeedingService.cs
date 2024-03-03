using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDespesas.Models;
using AppDespesas.Models.Enums;

namespace AppDespesas.Data
{
    public class SeedingService
    {
        private AppDespesasContext _context;

        public SeedingService(AppDespesasContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Despesa.Any() ||
                _context.RegistrosDespesas.Any())
            {
                return;
            }

            Despesa d1 = new Despesa(4, "Despesa com Veículo");

            RegistroDespesas rd1 = new RegistroDespesas(1, new DateTime(2014, 02, 03), "Kochi", 25.00, d1, TipoPagamento.Dinheiro);

            _context.Despesa.AddRange(d1);
            _context.RegistrosDespesas.AddRange(rd1);
            _context.SaveChanges();
        }
    }
}
