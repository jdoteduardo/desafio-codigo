using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Service.DTO
{
    public class PessoaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
        public int IdCidade { get; set; }
        public CidadeDTO Cidade { get; set; }

        public PessoaDTO()
        {

        }

        public PessoaDTO(int id, string nome, string cpf, int idade, int idCidade, CidadeDTO cidade)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Idade = idade;
            IdCidade = idCidade;
            Cidade = cidade;
        }
    }
}
