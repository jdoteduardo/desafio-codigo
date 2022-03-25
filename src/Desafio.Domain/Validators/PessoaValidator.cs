using Desafio.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Validators
{
    public class PessoaValidator : AbstractValidator<Pessoa>
    {
        public PessoaValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MaximumLength(300)
                .WithMessage("O nome deve ter até 300 caracteres");

            RuleFor(x => x.CPF)
                .NotNull()
                .WithMessage("O CPF não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O CPF não pode ser vazio.")

                .Length(11)
                .WithMessage("CPF deve conter 11 caracteres.");

            RuleFor(x => x.IdCidade)
                .NotNull()
                .WithMessage("O IdCidade não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O IdCidade não pode ser vazio.");

            RuleFor(x => x.Idade)
                .NotNull()
                .WithMessage("A idade não pode ser nula.")

                .NotEmpty()
                .WithMessage("A idade não pode ser vazio.");
        }
    }
}
