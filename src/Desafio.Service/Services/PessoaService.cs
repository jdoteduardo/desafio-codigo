using AutoMapper;
using Desafio.Core.Exceptions;
using Desafio.Domain.Entities;
using Desafio.Infra.Interfaces;
using Desafio.Service.DTO;
using Desafio.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Service.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IMapper _mapper;

        public PessoaService(IMapper mapper, IPessoaRepository pessoaRepository, ICidadeRepository cidadeRepository)
        {
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
            _cidadeRepository = cidadeRepository;
        }

        public async Task<PessoaDTO> Atualizar(PessoaDTO pessoaDTO)
        {
            var existePessoa = await _pessoaRepository.GetById(pessoaDTO.Id);

            if (existePessoa != null)
            {
                throw new DomainException("Não existe uma pessoa com esse ID informado.");
            }

            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);
            pessoa.Validate();

            var atualizarPessoa = await _pessoaRepository.Atualizar(pessoa);

            return _mapper.Map<PessoaDTO>(atualizarPessoa);
        }

        public async Task<PessoaDTO> Criar(PessoaDTO pessoaDTO)
        {
            var existePessoa = await _pessoaRepository.GetByNome(pessoaDTO.Nome);
            var existeCidade = await _cidadeRepository.GetById(pessoaDTO.IdCidade);

            var cidade = _mapper.Map<CidadeDTO>(existeCidade);

            if (existePessoa.Count > 0)
            {
                throw new DomainException("Já existe uma pessoa com esse nome informado.");
            }

            if (cidade == null)
            {
                throw new DomainException("Não existe uma cidade com esse ID informado.");
            }

            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);

            pessoa.Validate();

            var criarPessoa = await _pessoaRepository.Criar(pessoa);

            return _mapper.Map<PessoaDTO>(criarPessoa);
        }

        public async Task<List<PessoaDTO>> GetAll()
        {
            var allPessoas = await _pessoaRepository.GetAll();

            return _mapper.Map<List<PessoaDTO>>(allPessoas);
        }

        public async Task<PessoaDTO> GetById(int id)
        {
            var pessoa = await _pessoaRepository.GetById(id);

            return _mapper.Map<PessoaDTO>(pessoa);
        }

        public async Task<List<PessoaDTO>> GetByIdade(int idade)
        {
            var idadePessoas = await _pessoaRepository.GetByIdade(idade);

            return _mapper.Map<List<PessoaDTO>>(idadePessoas);
        }

        public async Task<List<PessoaDTO>> GetByNome(string nome)
        {
            var nomePessoas = await _pessoaRepository.GetByNome(nome);

            return _mapper.Map<List<PessoaDTO>>(nomePessoas);
        }

        public async Task Remover(int id)
        {
            await _pessoaRepository.Remover(id);
        }
    }
}
