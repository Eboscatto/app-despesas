using AppDespesas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDespesas.Services
{
    public class RegistrosService
    {
        private readonly AppDespesasContext _context;

        public RegistrosService(AppDespesasContext context)
        {
            _context = context;
        }

        public List<RegistroDespesas> FindAll()
        {
            return _context.RegistrosDespesas.ToList();
        }

        public void Insert(RegistroDespesas obj)
        {
            //obj.Despesa = _context.Despesa.First();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public RegistroDespesas FindById(int id)
        {
            return _context.RegistrosDespesas.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)//Abre a tela de confirmação de deletar
        {
            var obj = _context.RegistrosDespesas.Find(id);
            _context.RegistrosDespesas.Remove(obj);
            _context.SaveChanges();
        }

    }
}
