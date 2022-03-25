using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("INT");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR(300)");

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("CPF")
                .HasColumnType("VARCHAR(11)");

            builder.Property(x => x.IdCidade)
                .IsRequired()
                .HasColumnName("Id_Cidade")
                .HasColumnType("INT");

            builder.Property(x => x.Idade)
                .IsRequired()
                .HasColumnName("Idade")
                .HasColumnType("INT");

            // FK - Relacionamentos
            builder
                .HasOne(x => x.Cidade)
                .WithOne()
                .HasForeignKey<Pessoa>(x => x.IdCidade)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
