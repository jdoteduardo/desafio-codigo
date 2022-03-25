using Desafio.Core.Exceptions;
using Desafio.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Entities
{
    public class Pessoa : Base
    {
        public string CPF { get; private set; }
        public int Idade { get; private set; }
        public int IdCidade { get; private set; }
        public Cidade Cidade { get; private set; }

        protected Pessoa()
        {

        }

        public Pessoa(string cpf, int idCidade, int idade, Cidade cidade)
        {
            CPF = cpf;
            IdCidade = idCidade;
            Idade = idade;
            Cidade = cidade;
            _errors = new List<string>();
        }

        public void ChangeIdade(int idade)
        {
            Idade = idade;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new PessoaValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Alguns campos estão inválidos", _errors);
            }

            return true;
        }
    }
}
