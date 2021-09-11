﻿using System.Collections.Generic;

namespace Fintech.Dominio.Entidades
{
    public abstract class Conta
    {
        public int Id { get; set; }
        public Agencia Agencia { get; set; }
        public int Numero { get; set; }
        public string DigitoVerificador { get; set; }
        public decimal Saldo { get; set; }
        public Cliente Cliente { get; set; }

        public abstract List<string> Validar();

        public List<string> ValidarBase()
        {
            var erros = new List<string>();

            if (Numero <= 0)
            {
                erros.Add("O número da conta dever ser maior que zero.");
            }

            if (string.IsNullOrEmpty(DigitoVerificador))
            {
                erros.Add("O dígito verificador da conta é obrigatório.");
            }

            //if (Limite )
            //{

            //}

            return erros;
        }

        public virtual void EfetuarOperacao(decimal valor, Operacao operacao)
        {
            switch (operacao)
            {
                case Operacao.Deposito:
                    Saldo += valor;
                    break;
                case Operacao.Saque:
                    if (Saldo >= valor)
                    {
                        Saldo -= valor; 
                    }
                    break;
            }
        }
    }
}