using System;

namespace CSharp.Capitulo02.GeradorSenha
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Informe a quantidade de dígitos da senha (entre 4 e 10): ");

            var quantidadeDigitos = 0;

            while (quantidadeDigitos == 0)
            {
                quantidadeDigitos = ObterQuantidadeDigitos();
            }

            //var quantidadeDigitos = Convert.ToInt32(Console.ReadLine());

            //if (quantidadeDigitos < 4 || quantidadeDigitos > 10 || quantidadeDigitos % 2 != 0)
            if (quantidadeDigitos is < 4 or > 10 || quantidadeDigitos % 2 != 0)
            {
                Console.WriteLine($"A quantidade de dígitos {quantidadeDigitos} é inválida de acordo com as regras.");
                Console.ReadKey();
                return;
            }

            var senha = string.Empty;
            var randomico = new Random();

            for (int i = 1; i <= quantidadeDigitos; i++)
            {
                var digito = randomico.Next(10);

                senha += digito;
            }

            Console.WriteLine($"Senha gerada: {senha}");
        }

        private static int ObterQuantidadeDigitos()
        {
            int.TryParse(Console.ReadLine(), out int quantidadeDigitos);



            return quantidadeDigitos;
        }
    }
}
