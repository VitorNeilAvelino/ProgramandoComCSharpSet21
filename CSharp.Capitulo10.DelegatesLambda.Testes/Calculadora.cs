using System;

namespace CSharp.Capitulo10.DelegatesLambda.Testes
{
    public delegate int EfetuarOperacao(int x, int y);
    public static class Calculadora
    {
        private static int Somar(int x, int y)
        {
            return x + y;
        }

        private static int Subtrair(int x, int y)
        {
            return x - y;
        }

        private static int Multiplicar(int x, int y, int z)
        {
            return x * y * z;
        }

        public static EfetuarOperacao ObterOperacao(TipoOperacao tipoOperacao)
        {
            switch (tipoOperacao)
            {
                case TipoOperacao.Soma:
                    return Somar;
                case TipoOperacao.Subtracao:
                    return Subtrair;
                case TipoOperacao.Multiplicacao:
                    //return Multiplicar;
                    break;
                case TipoOperacao.Divisao:
                    break;
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}