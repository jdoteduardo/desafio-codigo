using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Service.DTO
{
    public class CidadeDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }

        public CidadeDTO()
        {

        }

        public CidadeDTO(int id, string nome, string uf)
        {
            Id = id;
            Nome = nome;
            UF = uf;
        }
    }
}
