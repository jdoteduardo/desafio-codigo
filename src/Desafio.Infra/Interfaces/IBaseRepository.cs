using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Interfaces
{
    public interface IBaseRepository<T> where T: Base
    {
        Task<T> Criar(T obj);
        Task<T> Atualizar(T obj);
        Task Remover(int id);
        Task<T> GetById(int id);
        Task<List<T>> GetByNome(string nome);
        Task<List<T>> GetAll();
    }
}
