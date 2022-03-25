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
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IMapper _mapper;

        public CidadeService(IMapper mapper, ICidadeRepository cidadeRepository)
        {
            _mapper = mapper;
            _cidadeRepository = cidadeRepository;
        }

        public async Task<CidadeDTO> Atualizar(CidadeDTO cidadeDTO)
        {
            var existeCidade = await _cidadeRepository.GetById(cidadeDTO.Id);

            if (existeCidade == null)
            {
                throw new DomainException("Não existe uma cidade com esse ID informado.");
            }

            var cidade = _mapper.Map<Cidade>(cidadeDTO);
            cidade.Validate();

            var atualizarCidade = await _cidadeRepository.Atualizar(cidade);

            return _mapper.Map<CidadeDTO>(atualizarCidade);
        }

        public async Task<CidadeDTO> Criar(CidadeDTO cidadeDTO)
        {
            var existeCidade = await _cidadeRepository.GetByNome(cidadeDTO.Nome);

            if (existeCidade.Count > 0)
            {
                throw new DomainException("Já existe uma cidade com esse nome informado.");
            }

            var cidade = _mapper.Map<Cidade>(cidadeDTO);
            cidade.Validate();

            var criarCidade = await _cidadeRepository.Criar(cidade);

            return _mapper.Map<CidadeDTO>(criarCidade);
        }

        public async Task<List<CidadeDTO>> GetAll()
        {
            var allCidades = await _cidadeRepository.GetAll();

            return _mapper.Map<List<CidadeDTO>>(allCidades);
        }

        public async Task<CidadeDTO> GetById(int id)
        {
            var cidade = await _cidadeRepository.GetById(id);

            return _mapper.Map<CidadeDTO>(cidade);
        }

        public async Task<List<CidadeDTO>> GetByNome(string nome)
        {
            var cidadesPorNome = await _cidadeRepository.GetByNome(nome);

            return _mapper.Map<List<CidadeDTO>>(cidadesPorNome);
        }

        public async Task<List<CidadeDTO>> GetByUF(string uf)
        {
            var cidadesPorUf = await _cidadeRepository.GetByUF(uf);

            return _mapper.Map<List<CidadeDTO>>(cidadesPorUf);
        }

        public async Task Remover(int id)
        {
            await _cidadeRepository.Remover(id);
        }
    }
}
