using AppDespesas.Models;
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

        public async Task<List<RegistroDespesas>> FindAllAsync()
        {
            return await _context.RegistrosDespesas.Include(obj => obj.Despesa).ToListAsync();
        }

        public async Task InsertAsync(RegistroDespesas obj)
        {
            //obj.Despesa = _context.Despesa.First();
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task <RegistroDespesas> FindByIdAsync(int id)
        {   //Faz o eager loading carregando o objeto despesa junto
            return await _context.RegistrosDespesas.Include(obj => obj.Despesa).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)//Abre a tela de confirmação de deletar
        {
            var obj = await _context.RegistrosDespesas.FindAsync(id);
            _context.RegistrosDespesas.Remove(obj);
            await _context.SaveChangesAsync();
        }      
        
        //Editar/Atulalizar dados
        public async Task UpdateAsync(RegistroDespesas obj)
        {
            bool hasAny = await _context.RegistrosDespesas.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não existe!");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }            
        }
        
    }
}
