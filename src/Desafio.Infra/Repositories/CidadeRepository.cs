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
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        private readonly DesafioContext _context;

        public CidadeRepository(DesafioContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<List<Cidade>> GetByUF(string uf)
        {
            return await _context.Set<Cidade>()
                                    .AsNoTracking()
                                    .Where(x => x.UF.ToLower() == uf.ToLower())
                                    .ToListAsync();
        }
    }
}
