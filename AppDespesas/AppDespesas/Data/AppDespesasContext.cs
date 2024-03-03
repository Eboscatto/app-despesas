
using Microsoft.EntityFrameworkCore;
using AppDespesas.Models;

namespace AppDespesas.Models
{
    public class AppDespesasContext : DbContext
    {
        public AppDespesasContext (DbContextOptions<AppDespesasContext> options)
            : base(options)
        {

        }
        public DbSet<Despesa> Despesa { get; set; }
        public DbSet< RegistroDespesas> RegistrosDespesas  { get; set; }
    }
}
