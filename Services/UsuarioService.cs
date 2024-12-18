﻿using Microsoft.EntityFrameworkCore;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaOrcamentario.Services
{
    public class UsuarioService : IService<UsuarioModel>
    {
        readonly DataContext _dbContext;

        public UsuarioService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(UsuarioModel usuario)
        {
             _dbContext.Add(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(UsuarioModel usuario)
        {
            _dbContext.Update(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var usuId = await _dbContext.TBUSUARIO.FindAsync(id);

            if (usuId != null)
            {
                _dbContext.TBUSUARIO.Remove(usuId);
                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<UsuarioModel>> FindAll()
        {
            return await _dbContext.TBUSUARIO.ToListAsync();
        }
    }

}
