﻿using AppDespesas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppDespesas.Services.Exceptions;

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
            return _context.RegistrosDespesas.Include(obj => obj.Despesa).ToList();
        }

        public void Insert(RegistroDespesas obj)
        {
            //obj.Despesa = _context.Despesa.First();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public RegistroDespesas FindById(int id)
        {   //Faz o eager loading carregando o objeto despesa junto
            return _context.RegistrosDespesas.Include(obj => obj.Despesa).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)//Abre a tela de confirmação de deletar
        {
            var obj = _context.RegistrosDespesas.Find(id);
            _context.RegistrosDespesas.Remove(obj);
            _context.SaveChanges();
        }      
        
        //Editar/Atulalizar dados
        public void Update(RegistroDespesas obj)
        {
            if (!_context.RegistrosDespesas.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não existe!");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }            
        }
        
    }
}