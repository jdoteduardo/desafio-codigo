using AutoMapper;
using Desafio.API.Utilities;
using Desafio.API.ViewModels;
using Desafio.Core.Exceptions;
using Desafio.Service.DTO;
using Desafio.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Desafio.API.Controllers
{
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICidadeService _cidadeService;

        public CidadeController(IMapper mapper, ICidadeService cidadeService)
        {
            _mapper = mapper;
            _cidadeService = cidadeService;
        }

        [HttpPost]
        [Route("/api/v1/cidades/criar")]
        public async Task<IActionResult> Criar([FromBody] CriarCidadeViewModel cidadeViewModel)
        {
            try
            {
                var cidadeDTO = _mapper.Map<CidadeDTO>(cidadeViewModel);

                var criarCidade = await _cidadeService.Criar(cidadeDTO);

                return Ok(new ResultViewModel { Mensagem = "Cidade criada com sucesso!", Sucesso = true, Dado = criarCidade });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Route("/api/v1/cidades/atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] UpdateCidadeViewModel cidadeViewModel)
        {
            try
            {
                var cidadeDTO = _mapper.Map<CidadeDTO>(cidadeViewModel);

                var updateCidade = await _cidadeService.Atualizar(cidadeDTO);

                return Ok(new ResultViewModel { Mensagem = "Cidade atualizada com sucesso!", Sucesso = true, Dado = updateCidade });
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
        [Route("/api/v1/cidades/remover/{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            try
            {
                await _cidadeService.Remover(id);

                return Ok(new ResultViewModel { Mensagem = "Cidade removida com sucesso!", Sucesso = true, Dado = null });
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
        [Route("/api/v1/cidades/get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cidade = await _cidadeService.GetById(id);

                if (cidade == null)
                    return Ok(new ResultViewModel { Mensagem = "Cidade não encontrada", Sucesso = true, Dado = cidade });

                return Ok(new ResultViewModel { Mensagem = "Cidade encontrada com sucesso!", Sucesso = true, Dado = cidade });
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
        [Route("/api/v1/cidades/get-by-nome/{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var cidade = await _cidadeService.GetByNome(nome);

                if (cidade.Count == 0)
                    return Ok(new ResultViewModel { Mensagem = "Cidade não encontrada", Sucesso = true, Dado = cidade });

                return Ok(new ResultViewModel { Mensagem = "Cidade encontrada com sucesso!", Sucesso = true, Dado = cidade });
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
        [Route("/api/v1/cidades/get-by-uf/{uf}")]
        public async Task<IActionResult> GetByUF(string uf)
        {
            try
            {
                var cidade = await _cidadeService.GetByUF(uf);

                if (cidade.Count == 0)
                    return Ok(new ResultViewModel { Mensagem = "Cidades não encontrada", Sucesso = true, Dado = cidade });

                return Ok(new ResultViewModel { Mensagem = "Cidades encontrada com sucesso!", Sucesso = true, Dado = cidade });
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
        [Route("/api/v1/cidades/get-all/")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cidade = await _cidadeService.GetAll();

                return Ok(new ResultViewModel { Mensagem = "Cidades encontradas com sucesso!", Sucesso = true, Dado = cidade });
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
