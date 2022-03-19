using Escola.Entidades;
using Escola.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Escola.Repositorios
{
    public class AlunoRepositorioMock : AlunoRepositorioJson
    {
        protected override string caminhoJson()
        {
            return "/Users/danilo/projetos/torne-se/aulas/dotnet_core/XUnitEscola/alunos_mock.json";
        }
    }
}
