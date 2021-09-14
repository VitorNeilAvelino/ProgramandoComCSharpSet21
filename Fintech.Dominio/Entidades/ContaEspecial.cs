namespace Fintech.Dominio.Entidades
{
    public class ContaEspecial : ContaCorrente
    {
        public ContaEspecial(Agencia agencia, int numero, string digitoVerificador, decimal limite) : base(agencia, numero, digitoVerificador)
        {
            Limite = limite;
        }

        public decimal Limite { get; set; }

        public void EfetuarOperacao(decimal valor, Operacao operacao)
        {
            base.EfetuarOperacao(valor, operacao, Limite);
        }
    }
}