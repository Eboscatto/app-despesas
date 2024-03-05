
using AppDespesas.Models.Enums;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace AppDespesas.Models
{
    public class RegistroDespesas
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} requerida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
        [Display(Name = "Histórico")]
        public string Historico { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(0.1, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        public double Valor { get; set; }
        public Despesa Despesa { get; set; } // Um registro de despesa pode ter apenas um tipo de despesa
        public int DespesaId { get; set; }
        public TipoPagamento Pagamento  { get; set; }

        public RegistroDespesas()
        {

        }

        public RegistroDespesas(int id, DateTime data, string historico, double valor, Despesa despesa, TipoPagamento pagamento)
        {
            Id = id;
            Data = data;
            Historico = historico;
            Valor = valor;
            Despesa = despesa;
            Pagamento = pagamento;
        }
    }
}
