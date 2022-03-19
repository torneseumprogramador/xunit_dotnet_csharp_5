using Escola.Entidades;
using Escola.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Escola.Repositorios
{
    public class AlunoRepositorioMockMemoria : IRepositorio
    {
        private static List<Aluno> alunos = new List<Aluno>();

        public int Quantidade()
        {
            return alunos.Count;
        }

        public void Salvar(Aluno aluno)
        {
            alunos.Add(aluno);
        }

        public List<Aluno> Todos()
        {
            return alunos;
        }
    }
}
