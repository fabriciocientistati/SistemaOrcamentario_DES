using SistemaOrcamentario.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaOrcamentario.Services
{
    public interface IService<T>
    {
        Task Create(T usuario);
        Task Update(T usuario);
        Task Delete(int id);
        Task<IEnumerable<T>> FindAll();
    }
}
