using Desafio.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Service.Interfaces
{
    public interface ICidadeService
    {
        Task<CidadeDTO> Criar(CidadeDTO cidadeDTO);
        Task<CidadeDTO> Atualizar(CidadeDTO cidadeDTO);
        Task Remover(int id);
        Task<CidadeDTO> GetById(int id);
        Task<List<CidadeDTO>> GetByNome(string nome);
        Task<List<CidadeDTO>> GetAll();
        Task<List<CidadeDTO>> GetByUF(string uf);
    }
}
