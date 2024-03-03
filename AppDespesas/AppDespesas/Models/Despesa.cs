using System;
using System.Linq;
using System.Collections.Generic;
using AppDespesas.Migrations;

namespace AppDespesas.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<RegistroDespesas> Registros { get; set; } = new List<RegistroDespesas>();// Despesa pode ter vários registros de despesas

        public Despesa()
        {

        }

        public Despesa(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public void AddRegistros(RegistroDespesas rd)
        {
            Registros.Add(rd);
        }

        public void RemoveRegistros(RegistroDespesas rd)
        {
            Registros.Remove(rd);
        }

        public double TotalDespesas(DateTime initial, DateTime final)
        {
            return Registros.Where(rd => rd.Data >= initial && rd.Data <= final).Sum(rd => rd.Valor);
        }
    }
}