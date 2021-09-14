using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Dominio.Entidades.Tests
{
    [TestClass()]
    public class ContaEspecialTests
    {
        [TestMethod()]
        public void EfetuarOperacaoTest()
        {
            var conta = new ContaEspecial(new Agencia(), 123, "0", 1000);

            conta.EfetuarOperacao(50, Operacao.Deposito);
            Assert.IsTrue(conta.Saldo == 50);

            conta.EfetuarOperacao(20, Operacao.Saque);
            Assert.IsTrue(conta.Saldo == 30);

            conta.EfetuarOperacao(40, Operacao.Saque);
            Assert.IsTrue(conta.Saldo == -10);

            conta.EfetuarOperacao(990, Operacao.Saque);
            Assert.IsTrue(conta.Saldo == -1000);

            conta.EfetuarOperacao(10, Operacao.Saque);
            Assert.IsTrue(conta.Saldo == -1000);

            conta.EfetuarOperacao(1000, Operacao.Deposito);
            Assert.IsTrue(conta.Saldo == 0);

            Assert.AreEqual(conta.Movimentos.Count, 5);

            var somaDepositos = conta.Movimentos
                .Where(m => m.Operacao == Operacao.Deposito)
                .Sum(m => m.Valor);

            var somaSaques = conta.Movimentos
                .Where(m => m.Operacao == Operacao.Saque)
                .Sum(m => m.Valor);

            //conta.Saldo = 5000;

            Assert.AreEqual(conta.Saldo, somaDepositos - somaSaques);
        }
    }
}