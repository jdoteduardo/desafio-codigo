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
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        private readonly DesafioContext _context;

        public PessoaRepository(DesafioContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<List<Pessoa>> GetByIdade(int idade)
        {
            return await _context.Set<Pessoa>()
                                    .AsNoTracking()
                                    .Where(x => x.Idade == idade)
                                    .ToListAsync();
        }
    }
}
