using System.Collections.Generic;

namespace Fintech.Dominio.Entidades
{
    public class Poupanca : Conta
    {
        public Poupanca(Agencia agencia, int numero, string digitoVerificador) : base(agencia, numero, digitoVerificador)
        {
        }

        public decimal TaxaRendimento { get; set; }

        public override List<string> Validar()
        {
            var erros = base.ValidarBase();

            if (TaxaRendimento < 0)
            {
                erros.Add("A taxa não pode ser menor que zero.");
            }

            return erros;
        }
    }
}