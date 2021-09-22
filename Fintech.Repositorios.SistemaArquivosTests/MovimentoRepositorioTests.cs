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

        [TestMethod]
        public void DelegatePredicateTeste()
        {
            var movimentos = repositorio.Selecionar(22, 233);

            Predicate<Movimento> obterDepositos = m => m.Operacao == Operacao.Deposito;

            //var depositos = movimentos.FindAll(EncontrarMovimentoDeposito);
            //var depositos = movimentos.FindAll(obterDepositos);
            var depositos = movimentos.FindAll(m => m.Operacao == Operacao.Deposito);

            depositos.ForEach(d => Console.WriteLine(d.Valor));
        }

        private bool EncontrarMovimentoDeposito(Movimento m)
        {
            return m.Operacao == Operacao.Deposito;
        }

        [TestMethod]
        public void DelegateFuncTeste()
        {
            var movimentos = repositorio.Selecionar(22, 233);

            Func<Movimento, decimal> obterCampoValor = m => m.Valor;

            //var totalDepositos = movimentos.Where(m => m.Operacao == Operacao.Deposito).Sum(RetornarCampoSoma);
            //var totalDepositos = movimentos.Where(m => m.Operacao == Operacao.Deposito).Sum(obterCampoValor);
            var totalDepositos = movimentos.Where(m => m.Operacao == Operacao.Deposito).Sum(mov => mov.Valor);

            Console.WriteLine(totalDepositos);
        }

        private decimal RetornarCampoSoma(Movimento m)
        {
            return m.Valor;
        }

        [TestMethod]
        public void OrderByTeste()
        {
            var movimentos = repositorio.Selecionar(22, 233)
                .OrderBy(m => m.Valor)
                .ThenBy(m => m.Operacao)
                .ThenByDescending(m => m.Data);

            //var primeiro = movimentos.First();
            var primeiro = movimentos.FirstOrDefault();

            Console.WriteLine(primeiro?.Valor.ToString());
        }

        [TestMethod]
        public void CountTeste()
        {
            var qtdDepositos = repositorio.Selecionar(22, 233)
                .Count(m => m.Operacao == Operacao.Deposito);

            Console.WriteLine(qtdDepositos);
        }

        [TestMethod]
        public void LikeTeste()
        {
            var movimentos = repositorio.Selecionar(22, 233)
                .Where(m => m.Data.ToString().Contains("16/09/2021")).ToList();

            movimentos.ForEach(m => Console.WriteLine(m.Data));
        }

        [TestMethod]
        public void MinTeste()
        {
            var menorMovimento = repositorio.Selecionar(22, 233).Min(m => m.Valor);
            //var menorMovimento = repositorio.Selecionar(22, 233).Min();

            Console.WriteLine(menorMovimento);
        }

        [TestMethod]
        public void SkipTakeTeste()
        {
            var movimentos = repositorio.Selecionar(22, 233).Skip(1).Take(1).ToList();

            movimentos.ForEach(m => Console.WriteLine($"{m.Data} - {m.Valor}"));
        }

        [TestMethod]
        public void GroupByTeste()
        {
            var agrupamento = repositorio.Selecionar(22, 233)
                .GroupBy(m => m.Operacao)
                .Select(g => new { Operacao = g.Key, Total = g.Sum(m => m.Valor)});

            // var veiculo = { };

            foreach (var item in agrupamento)
            {
                Console.WriteLine($"{item.Operacao}: {item.Total:c}");
            }
        }
    }
}