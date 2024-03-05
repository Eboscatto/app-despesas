using AppDespesas.Models;
using System.Collections.Generic;
using System.Linq;

namespace AppDespesas.Services
{
    public class DespesaService
    {
        private readonly AppDespesasContext _context;

        public DespesaService(AppDespesasContext context)
        {
            _context = context;
        }

        public List<Despesa> FindAll()
        {
            return _context.Despesa.OrderBy(x => x.Nome).ToList();
        }

    }
}
