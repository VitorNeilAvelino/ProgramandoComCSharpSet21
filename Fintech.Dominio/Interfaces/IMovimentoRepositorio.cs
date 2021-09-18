using Fintech.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fintech.Dominio.Interfaces
{
    public interface IMovimentoRepositorio
    {
        void Inserir(Movimento movimento);
        List<Movimento> Selecionar(int numeroAgencia, int numeroConta);
        Task<List<Movimento>> SelecionarAsync(int numeroAgencia, int numeroConta);
        void Atualizar(Movimento movimento) => throw new InvalidOperationException();
        void Excluir(int id)
        {
            throw new InvalidOperationException();
        }
    }
}