using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharp.Capitulo08.Colecoes.Testes
{
    [TestClass]
    public class VetoresTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            var inteiros = new int[5];
            inteiros[0] = 14;
            inteiros[1] = -8;
            //inteiros[5] = 0;

            var decimais = new decimal[] { 0.4m, 0.9m, 4, 7.8m };

            string[] nomes = { "Vítor", "Avelino" };

            var chars = new[] { 'a', 'b', 'c' };

            foreach (var @decimal in decimais)
            {
                Console.WriteLine(@decimal);
            }

            Console.WriteLine($"O tamanho do vetor {nameof(decimais)} é {decimais.Length}.");
        }

        [TestMethod]
        public void RedimensionamentoTeste()
        {
            var decimais = new decimal[] { 0.4m, 0.9m, 4, 7.8m };

            Array.Resize(ref decimais, 5);

            decimais[4] = 2.3m;
        }

        [TestMethod]
        public void OrdenacaoTeste()
        {
            var decimais = new decimal[] { 0.4m, 7m, 3.2m, -1.4m };

            Array.Sort(decimais);

            Assert.AreEqual(decimais[0], -1.4m);
        }

        [TestMethod]
        public void ParamsTeste()
        {
            var decimais = new decimal[] { 0.3m, 0.8m, 0.2m, 4, 3.3m };

            Console.WriteLine(Media(decimais));
            Console.WriteLine(Media(0.9m, 8.73m, -6m));
        }

        private decimal Media(decimal x, decimal y)
        {
            //x = 14.3m;
            //y = 23.4m;
            decimal soma = x + y;

            decimal total = soma / 2;

            return total;
        }

        private decimal Media(params decimal[] decimais)
        {
            //decimais = new decimal[] { 0.3m, 0.8m, 0.2m, 4, 3.3m };
            
            decimal soma = 0;

            foreach (var numero in decimais)
            {
                soma += numero;
            }

            decimal media = soma / decimais.Length;

            return media;
        }

        [TestMethod]
        public void TodaStringEhUmVetorTeste()
        {
            var nome = "Vítor";

            Assert.AreEqual(nome[0], 'V');

            //nome += " Avelino";
            // StringBuilder

            foreach (var @char in nome)
            {
                Console.Write(@char);
            }
        }
    }
}
