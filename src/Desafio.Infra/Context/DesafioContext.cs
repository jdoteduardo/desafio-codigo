using Desafio.Domain.Entities;
using Desafio.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Context
{
    public class DesafioContext : DbContext
    {
        public DesafioContext() { }

        public DesafioContext(DbContextOptions<DesafioContext> options) : base(options) { }

        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CidadeMap());
            builder.ApplyConfiguration(new PessoaMap());
        }
    }
}
