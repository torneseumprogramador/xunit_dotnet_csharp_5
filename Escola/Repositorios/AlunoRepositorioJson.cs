using Escola.Entidades;
using Escola.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Escola.Repositorios
{
    public class AlunoRepositorioJson : IRepositorio
    {
        protected virtual string caminhoJson()
        {
            return "/Users/danilo/projetos/torne-se/aulas/dotnet_core/XUnitEscola/alunos.json";
        }

        public int Quantidade()
        {
            return this.Todos().Count;
        }

        public List<Aluno> Todos()
        {
            var alunos = new List<Aluno>();
            if (File.Exists(this.caminhoJson()))
            {
                var conteudo = File.ReadAllText(this.caminhoJson());
                alunos = JsonConvert.DeserializeObject<List<Aluno>>(conteudo);
            }

            return alunos;
        }

        public void Salvar(Aluno aluno)
        {
            var alunos = this.Todos();
            alunos.Add(aluno);
            File.WriteAllText(this.caminhoJson(), JsonConvert.SerializeObject(alunos));
        }
    }
}
