using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintech.Dominio.Entidades;

namespace Fintech.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        private readonly MovimentoRepositorio repositorio = new("Dados\\Movimento.txt");

        [TestMethod()]
        public void InserirTest()
        {
            var agencia = new Agencia();
            agencia.Numero = 22;

            var contaFake = new ContaCorrente(agencia, 233, "4");
            var operacao = new Movimento(50, Operacao.Deposito);
            operacao.Conta = contaFake;
            
            repositorio.Inserir(operacao);
        }

        [TestMethod()]
        public void SelecionarTest()
        {
            var movimentos = repositorio.Selecionar(22, 233);

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Data} - {movimento.Guid} - {movimento.Operacao} - {movimento.Valor}");
            }
        }

        [TestMethod]
        public void DelegateActionTeste()
        {
            var movimentos = repositorio.Selecionar(22, 233);

            Action<Movimento> writeLine = movimento => Console.WriteLine($"{movimento.Data} - {movimento.Guid} - {movimento.Operacao} - {movimento.Valor}");

            //movimentos.ForEach(EscreverMovimento);
            //movimentos.ForEach(writeLine);
            movimentos.ForEach(m => Console.WriteLine($"{m.Data} - {m.Valor:c}"));
        }

        private void EscreverMovimento(Movimento movimento)
        {
            Console.WriteLine($"{movimento.Data} - {movimento.Guid} - {movimento.Operacao} - {movimento.Valor}");
        }
    }
}