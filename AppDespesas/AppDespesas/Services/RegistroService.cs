using AppDespesas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDespesas.Services
{
    public class RegistroService
    {
        private readonly AppDespesasContext _context;

        public RegistroService(AppDespesasContext context)
        {
            _context = context;
        }

        public List<RegistroDespesas> FindAll()
        {
            return _context.RegistrosDespesas.ToList();
        }

    }
}
