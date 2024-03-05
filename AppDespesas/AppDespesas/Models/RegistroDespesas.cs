
using AppDespesas.Models.Enums;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace AppDespesas.Models
{
    public class RegistroDespesas
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [Display(Name = "Histórico")]
        public string Historico { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
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
