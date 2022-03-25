using Desafio.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Service.Interfaces
{
    public interface IPessoaService
    {
        Task<PessoaDTO> Criar(PessoaDTO pessoaDTO);
        Task<PessoaDTO> Atualizar(PessoaDTO pessoaDTO);
        Task Remover(int id);
        Task<PessoaDTO> GetById(int id);
        Task<List<PessoaDTO>> GetByNome(string nome);
        Task<List<PessoaDTO>> GetAll();
        Task<List<PessoaDTO>> GetByIdade(int idade);
    }
}
