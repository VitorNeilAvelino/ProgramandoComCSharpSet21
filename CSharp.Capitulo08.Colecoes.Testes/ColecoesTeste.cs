using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo08.Colecoes.Testes
{
    [TestClass]
    public class ColecoesTeste
    {
        [TestMethod]
        public void ListTeste()
        {
            var inteiros = new List<int>(1000) { 1, 8, 33, 16, -78 };
            inteiros.Add(10);
            inteiros[0] = 13;
            //inteiros[20] = -25;
            inteiros.Add(27);
            inteiros.Add(-8);

            var maisInteiros = new List<int> { 16, 38, -7, 8 };

            inteiros.AddRange(maisInteiros);

            inteiros.Insert(2, 42);

            inteiros.Remove(8);

            inteiros.RemoveAt(5);

            inteiros.Sort();

            var primeiro = inteiros[0];
            primeiro = inteiros.First();

            var ultimo = inteiros.Last();
            ultimo = inteiros[inteiros.Count - 1];

            foreach (var inteiro in inteiros)
            {
                Console.WriteLine($"{inteiros.IndexOf(inteiro)}: {inteiro}");
            }
        }

        [TestMethod]
        public void DictionaryTeste()
        {
            var feriados = new Dictionary<DateTime, string>();

            feriados.Add(new DateTime(2022, 1, 1), "Ano Novo");
            feriados.Add(Convert.ToDateTime("25/12/2021"), "Natal");
            feriados.Add(Convert.ToDateTime("15/11/2021"), "Proclamação da República");
            //feriados.Add(Convert.ToDateTime("15/11/2021"), "Proclamação da República");

            var natal = feriados[Convert.ToDateTime("25/12/2021")];

            foreach (var feriado in feriados.OrderBy(f => f.Key))
            {
                Console.WriteLine($"{feriado.Key:d}: {feriado.Value}");
            }
        }
    }
}
