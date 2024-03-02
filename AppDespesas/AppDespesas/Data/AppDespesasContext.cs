using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppDespesas.Models;

namespace AppDespesas.Data
{
    public class AppDespesasContext : DbContext
    {
        public AppDespesasContext (DbContextOptions<AppDespesasContext> options)
            : base(options)
        {
        }

        public DbSet<AppDespesas.Models.Despesa> Despesa { get; set; }
    }
}
