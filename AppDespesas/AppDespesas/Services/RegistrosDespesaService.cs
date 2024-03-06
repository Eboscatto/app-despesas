using AppDespesas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AppDespesas.Services
{
    public class RegistrosDespesaService
    {
        private readonly AppDespesasContext _context;

        public RegistrosDespesaService(AppDespesasContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroDespesas>> FindByIdDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.RegistrosDespesas select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }
            return await result
                .Include(x => x.Despesa)//Fazendo join com a tabela Despesa
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }
    }
}
