using System.Collections.Generic;

namespace AppDespesas.Models.ViewModels
{
    public class RegistroFormViewModel
    {

        public RegistroDespesas RegistroDespesas { get; set; }
        public ICollection<Despesa> Despesas { get; set; }
    }
}
