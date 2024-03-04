
using AppDespesas.Models.Enums;
using System.Collections.Generic;
using System;

namespace AppDespesas.Models
{
    public class RegistroDespesas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Historico { get; set; }
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
