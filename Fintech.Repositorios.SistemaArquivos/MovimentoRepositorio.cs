using Fintech.Dominio.Entidades;
using Fintech.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Fintech.Repositorios.SistemaArquivos
{
    public class MovimentoRepositorio : IMovimentoRepositorio
    {
        private const string DiretorioBase = "Dados";

        public void Inserir(Movimento movimento)
        {
            string registro = $"{movimento.Guid}|{movimento.Conta.Agencia.Numero}|{movimento.Conta.Numero}|" +
                $"{movimento.Data}|{(int)movimento.Operacao}|{movimento.Valor}";

            if (!Directory.Exists(DiretorioBase))
            {
                Directory.CreateDirectory(DiretorioBase);
            }

            File.AppendAllText(@$"{DiretorioBase}\Movimento.txt", registro);
        }

        public List<Movimento> Selecionar(int numeroAgencia, int numeroConta)
        {
            throw new NotImplementedException();
        }
    }
}