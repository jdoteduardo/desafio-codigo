using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Interfaces
{
    public interface ICidadeRepository : IBaseRepository<Cidade>
    {
        Task<List<Cidade>> GetByUF(string uf);
    }
}
