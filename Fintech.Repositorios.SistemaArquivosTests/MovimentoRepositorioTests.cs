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
        [TestMethod()]
        public void InserirTest()
        {
            var agencia = new Agencia();
            agencia.Numero = 22;

            var contaFake = new ContaCorrente(agencia, 233, "4");
            var operacao = new Movimento(50, Operacao.Deposito);
            operacao.Conta = contaFake;

            var repositorio = new MovimentoRepositorio();
            repositorio.Inserir(operacao);
        }
    }
}