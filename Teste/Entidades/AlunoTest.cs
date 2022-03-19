using System;
using System.Collections.Generic;
using Escola.Entidades;
using Escola.Exceptions;
using Xunit;

namespace Teste
{
    public class AlunoTest
    {
        public static Aluno AlunoFake()
        {
            return new Aluno()
            {
                Id = 0,
                Nome = "teste",
                Matricula = "0012",
                Notas = new List<double>() { 7, 8, 9 },
                Cpf = "212112",
            };
        }

        [Trait("Instancia", "Aluno")]
        [Fact(DisplayName = "Validando criação de instância e campos da entidade")]
        public void ValidandoInstancia()
        {
            var aluno = AlunoFake();
            Assert.Equal(0, aluno.Id);
            Assert.Equal("teste", aluno.Nome);
            Assert.Equal("0012", aluno.Matricula);
            Assert.NotNull(aluno.Notas);
            Assert.Equal("212112", aluno.Cpf);
        }

        [Trait("Regra", "Aluno")]
        [Fact(DisplayName = "Validando média do aluno")]
        public void ValidarMedia()
        {
            Assert.Equal(8, AlunoFake().Media());
        }


        [Trait("Regra", "Aluno")]
        [Theory(DisplayName = "Testando CPF válidos")]
        [InlineData("744.505.170-83")]
        [InlineData("24132942015")]
        public void ValidarCpfAlunoValidos(string cpf)
        {
            var aluno = AlunoFake();
            aluno.Cpf = cpf;
            Assert.True(aluno.ValidarCPF());
        }


        [Trait("Regra", "Aluno")]
        [Theory(DisplayName = "Testando CPF inválidos")]
        [InlineData("000.000.000-00")]
        [InlineData("00000000000")]
        [InlineData("11111111111")]
        [InlineData("22222222222")]
        [InlineData("33333333333")]
        [InlineData("44444444444")]
        [InlineData("55555555555")]
        [InlineData("66666666666")]
        [InlineData("77777777777")]
        [InlineData("88888887888")]
        [InlineData("88888888888")]
        [InlineData("99999999999")]
        [InlineData("24132942011")]
        [InlineData("857.856.890-75")]
        public void ValidarCpfAlunoInvalidos(string cpf)
        {
            var aluno = AlunoFake();
            aluno.Cpf = cpf;
            Assert.False(aluno.ValidarCPF());
        }

        [Trait("Regra", "Aluno")]
        [Fact(DisplayName = "Validando situação do aluno")]
        public void ValidarSituacao()
        {
            Assert.Equal("aprovado", AlunoFake().Situacao().ToLower());
        }

        [Trait("Regra", "Aluno")]
        [Fact(DisplayName = "Validando notas formatadas para mostrar no programa")]
        public void ValidarNotasFormatadas()
        {
            Assert.Equal("7,8,9", AlunoFake().NotasFormadata());
        }

        [Trait("Exception", "Aluno")]
        [Fact(DisplayName = "Testando erro de validação Exception")]
        public void Excecao()
        {
            var aluno = AlunoFake();
            try
            {
                aluno.Valido();
            }
            catch (ErroDeValidacao erro)
            {
                Assert.Equal("Usuário precisa ter o nome preenchdo", erro.Message);
            }
            catch(Exception erro)
            {
                Assert.Equal("Erro generico", erro.Message);
            }
        }

        [Trait("Exception", "Aluno")]
        [Fact(DisplayName = "Testando erro de validação Exception ideal")]
        public void ExcecaoIdeal()
        {
            var aluno = AlunoFake();
            aluno.Nome = string.Empty;
            Assert.Throws<ErroDeValidacao>(
                () => aluno.Valido()
            );
        }

        [Trait("Exception", "Aluno")]
        [Fact(DisplayName = "Testando erro de validação Exception ideal(Generico)")]
        public void ExcecaoIdealException()
        {
            var aluno = AlunoFake();
            aluno.Nome = "Leandro";
            Assert.Throws<Exception>(
                () => aluno.Valido()
            );
        }
    }
}
