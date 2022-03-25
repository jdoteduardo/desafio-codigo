using AutoMapper;
using Desafio.API.Utilities;
using Desafio.API.ViewModels;
using Desafio.Core.Exceptions;
using Desafio.Domain.Entities;
using Desafio.Service.DTO;
using Desafio.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Desafio.API.Controllers
{
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPessoaService _pessoaService;

        public PessoaController(IMapper mapper, IPessoaService pessoaService)
        {
            _mapper = mapper;
            _pessoaService = pessoaService;
        }

        [HttpPost]
        [Route("/api/v1/pessoas/criar")]
        public async Task<IActionResult> Criar([FromBody] CriarPessoaViewModel pessoaViewModel)
        {
            try
            {
                var pessoaDTO = _mapper.Map<PessoaDTO>(pessoaViewModel);

                var criarPessoa = await _pessoaService.Criar(pessoaDTO);

                return Ok(new ResultViewModel { Mensagem = "Pessoa criada com sucesso!", Sucesso = true, Dado = criarPessoa });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Route("/api/v1/pessoas/atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] UpdatePessoaViewModel pessoaViewModel)
        {
            try
            {
                var pessoaDTO = _mapper.Map<PessoaDTO>(pessoaViewModel);

                var updatePessoa = await _pessoaService.Atualizar(pessoaDTO);

                return Ok(new ResultViewModel { Mensagem = "Pessoa atualizada com sucesso!", Sucesso = true, Dado = updatePessoa });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Route("/api/v1/pessoas/remover/{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            try
            {
                await _pessoaService.Remover(id);

                return Ok(new ResultViewModel { Mensagem = "Pessoa removida com sucesso!", Sucesso = true, Dado = null });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/pessoas/get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var pessoa = await _pessoaService.GetById(id);

                if (pessoa == null)
                    return Ok(new ResultViewModel { Mensagem = "Pessoa não encontrada", Sucesso = true, Dado = pessoa });

                return Ok(new ResultViewModel { Mensagem = "Pessoa encontrada com sucesso!", Sucesso = true, Dado = pessoa });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/pessoas/get-by-nome/{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var pessoa = await _pessoaService.GetByNome(nome);

                if (pessoa.Count == 0)
                    return Ok(new ResultViewModel { Mensagem = "Pessoa não encontrada", Sucesso = true, Dado = pessoa });

                return Ok(new ResultViewModel { Mensagem = "Pessoa encontrada com sucesso!", Sucesso = true, Dado = pessoa });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/pessoas/get-by-idade/{idade}")]
        public async Task<IActionResult> GetByIdade(int idade)
        {
            try
            {
                var pessoa = await _pessoaService.GetByIdade(idade);

                if (pessoa.Count == 0)
                    return Ok(new ResultViewModel { Mensagem = "Pessoa não encontrada", Sucesso = true, Dado = pessoa });

                return Ok(new ResultViewModel { Mensagem = "Pessoas encontradas com sucesso!", Sucesso = true, Dado = pessoa });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/pessoas/get-all/")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var pessoa = await _pessoaService.GetAll();

                if (pessoa.Count == 0)
                    return Ok(new ResultViewModel { Mensagem = "Não foi encontrada nenhuma pessoa cadastrada", Sucesso = true, Dado = pessoa });
                return Ok(new ResultViewModel { Mensagem = "Pessoas encontradas com sucesso!", Sucesso = true, Dado = pessoa });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}
