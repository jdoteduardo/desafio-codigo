using Desafio.Core.Exceptions;
using Desafio.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Entities
{
    public class Cidade : Base
    {
        public string UF { get; private set; }

        protected Cidade()
        {

        }

        public Cidade(string uf)
        {
            UF = uf;
            _errors = new List<string>();
        }

        public void ChangeUf(string uf)
        {
            UF = uf;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new CidadeValidator();
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
