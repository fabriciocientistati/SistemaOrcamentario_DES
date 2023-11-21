using SistemaOrcamentario.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaOrcamentario.Services
{
    public interface IService
    {
        Task Create(UsuarioModel usuario);
        Task Update(UsuarioModel usuario);
        Task Delete(int id);
        Task<IEnumerable<UsuarioModel>> FindAll();
    }
}
