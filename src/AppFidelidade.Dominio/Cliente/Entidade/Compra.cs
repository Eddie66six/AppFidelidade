using AppFidelidade.Dominio.Administracao.Entidade;
using System;
using System.Linq;

namespace AppFidelidade.Dominio.Cliente.Entidade
{
    public class Compra
    {
        protected Compra()
        {

        }
        public Compra(decimal valorCompra, Filial filial, Funcionario.Entidade.Funcionario funcionario, Cliente cliente, decimal? desconto)
        {
            ValorCompra = valorCompra;
            Filial = filial;
            Funcionario = funcionario;
            Cliente = cliente;
            Data = DateTime.UtcNow;

            _FinalizarCompra(desconto);
        }

        #region Metodos
        private void _FinalizarCompra(decimal? desconto)
        {
            if (!Cliente.Filiais.Any(p => p.Filial == Filial))
                Cliente.Filiais.Add(new FilialCliente(Cliente, Filial));

            if (desconto == null)
            {
                Regra = Filial.ObterRegra(ValorCompra);
                if (Regra != null)
                    valorCredito = Regra.ValorDaRegra;
            }
            else
            {
                if (Cliente.ObterCreditoNaFilial(Filial) >= desconto)
                {
                    Cliente.RetirarCredito(desconto.Value, Filial);
                    ValorCompra -= desconto.Value;
                    valorCredito = 0;
                }
            }
        }
        public void Creditar()
        {
            ValorRestanteCredito = valorCredito ?? 0;
            DataRetiradaCredito = DateTime.UtcNow;
            DataVencimentoCredito = DateTime.UtcNow.AddMonths(Filial.QtdeMesesVencimentoCredito);
            
        }

        public void RetirarCredito(decimal valor)
        {
            ValorRestanteCredito -= valor;
        }
        #endregion
        #region attr
        public long IdCompra { get; private set; }
        public decimal ValorCompra { get; private set; }
        public DateTime Data { get; private set; }
        public DateTime? DataRetiradaCredito { get; private set; }
        public DateTime? DataVencimentoCredito { get; set; }
        public decimal? valorCredito { get; private set; }
        public int IdFilial { get; private set; }
        public virtual Filial Filial { get; private set; }
        public int IdFuncionario { get; private set; }
        public virtual Funcionario.Entidade.Funcionario Funcionario { get; private set; }
        public int IdCliente { get; private set; }
        public virtual Cliente Cliente { get; private set; }
        public int? IdRegra { get; private set; }
        public virtual Regra Regra { get; private set; }
        public decimal ValorRestanteCredito { get; set; }
        #endregion
    }
}
