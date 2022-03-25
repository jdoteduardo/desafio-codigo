using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Core.Exceptions
{
    public class DomainException : Exception
    {
        internal List<string> _erros;
        public IReadOnlyCollection<string> Errors => _erros;

        public DomainException()
        {

        }

        public DomainException(string mensagem, List<string> erros) : base(mensagem)
        {
            _erros = erros;
        }

        public DomainException(string mensagem) : base(mensagem)
        {

        }

        public DomainException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {

        }
    }
}
