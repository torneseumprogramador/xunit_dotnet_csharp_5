using Escola.Exceptions;
using System.Collections.Generic;

namespace Escola.Entidades
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public List<double> Notas { get; set; }
        public string Cpf { get; set; }

        public double Media()
        {
            double somaNotas = 0;
            foreach (var nota in this.Notas)
                somaNotas += nota;

            return somaNotas / this.Notas.Count;
        }

        public string Situacao()
        {
            return (this.Media() > 6 ? "Aprovado" : "Reprovado");
        }

        public string NotasFormadata()
        {
            return string.Join(",", this.Notas);
        }

        public void Valido()
        {
            if (string.IsNullOrEmpty(this.Nome))
            {
                throw new ErroDeValidacao("Aluno precisa ter o nome preenchdo");
            }

            throw new System.Exception("Erro generico");
        }

        public bool ValidarCPF()
		{
			var cpf = this.Cpf;
            string valor = cpf.Replace(".", "");
            valor = valor.Replace("-", "");
            if (valor.Length != 11)
                return false;
            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
    }
}
