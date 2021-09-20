using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintech.Dominio.Entidades;

namespace Fintech.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        private readonly MovimentoRepositorio repositorio = new(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Fintech;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        [TestMethod()]
        public void InserirTest()
        {
            var agencia = new Agencia();
            agencia.Numero = 22;

            var contaFake = new ContaCorrente(agencia, 233, "4");
            var movimento = new Movimento(50, Operacao.Deposito);
            movimento.Conta = contaFake;

            repositorio.Inserir(movimento);
        }

        [TestMethod()]
        public void SelecionarAsyncTest()
        {
            var movimentos = repositorio.SelecionarAsync(22, 233).Result;

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Data} - {movimento.Valor:c}");
            }
        }
    }
}