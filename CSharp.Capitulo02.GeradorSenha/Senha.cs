using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo02.GeradorSenha
{
    public class Senha
    {
        //public Senha()
        //{
        //    Valor = Gerar();
        //}

        public Senha(int tamanho = TamanhoMinimo)
        {
            Tamanho = tamanho;
            Valor = Gerar();
        }

        public const int TamanhoMinimo = 4;
        public const int TamanhoMaximo = 10;
        public string Valor { get; set; }
        public int Tamanho { get; set; }// = TamanhoMinimo;

        public string Gerar()
        {
            var senha = string.Empty;
            var randomico = new Random();

            for (int i = 1; i <= Tamanho; i++)
            {
                var digito = randomico.Next(10);

                senha += digito;
            }

            return senha;
        }
    }
}
