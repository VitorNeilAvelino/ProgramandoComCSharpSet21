using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Capitulo02.GeradorSenha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo02.GeradorSenha.Tests
{
    [TestClass()]
    public class SenhaTests
    {
        [TestMethod()]
        public void GerarSenhaSemParametrosDeveRetornarSenhaPadrao()
        {
            var senha = new Senha();

            var valorSenha = senha.Gerar();

            Assert.IsTrue(valorSenha.Length == Senha.TamanhoMinimo);

            Console.WriteLine(valorSenha);
        }

        [TestMethod]
        public void ConstrutorPadraoDeveRetornarSenhaPadrao()
        {
            var senha = new Senha();

            Assert.IsTrue(senha.Valor.Length == Senha.TamanhoMinimo);
        }

        [TestMethod]
        [DataRow(4)]
        [DataRow(6)]
        [DataRow(8)]
        [DataRow(10)]
        public void ConstrutorParametrizadoDeveRetornarSenhaEspecifica(int tamanho)
        {
            var senha = new Senha(tamanho);

            Assert.IsTrue(senha.Valor.Length == tamanho);

            Console.WriteLine(senha.Valor);
        }
    }
}