using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Entities
{
    public abstract class Base
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        internal List<string> _errors;

        public IReadOnlyCollection<string> Errors => _errors;

        public abstract bool Validate();
    }
}
