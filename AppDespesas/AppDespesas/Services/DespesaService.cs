using AppDespesas.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AppDespesas.Services
{
    public class DespesaService
    {
        private readonly AppDespesasContext _context;

        public DespesaService(AppDespesasContext context)
        {
            _context = context;
        }

        public async Task<List<Despesa>> FindAllAsync()
        {
            //Expressão Linq
            return await _context.Despesa.OrderBy(x => x.Nome).ToListAsync();
        }

    }
}
