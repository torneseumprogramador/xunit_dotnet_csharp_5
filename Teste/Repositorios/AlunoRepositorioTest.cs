using System;
using Escola.Entidades;
using Escola.Repositorios;
using Xunit;

namespace Teste.Repositorios
{
    public class AlunoRepositorioTest
    {
        [Fact]
        public void TestandoRepoAluno()
        {
            var repo = new AlunoRepositorio(new AlunoRepositorioMockMemoria());
            repo.Salvar(AlunoTest.AlunoFake());

            var alunos = repo.Todos();
            var ultimoAluno = alunos[alunos.Count - 1];

            Assert.Equal("teste", ultimoAluno.Nome);

        }
    }
}
