using Desafio.API.ViewModels;
using System.Collections.Generic;

namespace Desafio.API.Utilities
{
    public static class Responses
    {
        public static ResultViewModel ApplicationErrorMessage()
        {
            return new ResultViewModel
            {
                Mensagem = "Ocorreu algum erro interno na aplicação, por favor tente novamente.",
                Sucesso = false,
                Dado = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message)
        {
            return new ResultViewModel
            {
                Mensagem = message,
                Sucesso = false,
                Dado = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ResultViewModel
            {
                Mensagem = message,
                Sucesso = false,
                Dado = errors
            };
        }

        public static ResultViewModel InternalServerErrorMessage()
        {
            return new ResultViewModel
            {
                Mensagem = "Ocorreu um erro interno na aplicação, por favor tente novamente.",
                Sucesso = false,
                Dado = null
            };
        }
    }
}
