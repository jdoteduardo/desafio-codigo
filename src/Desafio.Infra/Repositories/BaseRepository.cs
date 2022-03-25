using Desafio.Domain.Entities;
using Desafio.Infra.Context;
using Desafio.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly DesafioContext _context;

        public BaseRepository(DesafioContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Atualizar(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Criar(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>()
                                    .AsNoTracking()
                                    .ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            var obj = await _context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x => x.Id == id)
                                    .ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async Task<List<T>> GetByNome(string nome)
        {
            return await _context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x => x.Nome.ToLower() == nome.ToLower())
                                    .ToListAsync();
        }

        public virtual async Task Remover(int id)
        {
            var obj = await GetById(id);

            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
    }
}
