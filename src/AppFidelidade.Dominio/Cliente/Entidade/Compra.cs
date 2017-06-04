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
            Data = DateTime.Now;
            valorCredito = desconto;

            _FinalizarCompra(desconto);
        }

        #region Metodos
        private void _FinalizarCompra(decimal? desconto)
        {
            if (!Cliente.Filiais.Any(p => p.Filial == Filial))
                Cliente.Filiais.Add(new FilialCliente(Cliente, Filial));

            if (desconto == null)
                Regra = Filial.ObterRegra(ValorCompra);
            else
            {
                if (Cliente.Filiais.First(p => p.Filial == Filial).ValorCreditoNaFilial >= desconto)
                {
                    Cliente.RetirarCredito(desconto.Value, Filial);
                    ValorCompra -= desconto.Value;
                }
            }
        }
        public void Creditar(Cliente cliente)
        {
            cliente.InserirCredito(Regra.ValorDaRegra, Filial);
            DataRetiradaCredito = DateTime.Now;
        }
        #endregion
        #region attr
        public int IdCompra { get; private set; }
        public decimal ValorCompra { get; private set; }
        public DateTime Data { get; private set; }
        public DateTime? DataRetiradaCredito { get; private set; }
        public decimal? valorCredito { get; private set; }
        public int IdFilial { get; private set; }
        public virtual Filial Filial { get; private set; }
        public int IdFuncionario { get; private set; }
        public virtual Funcionario.Entidade.Funcionario Funcionario { get; private set; }
        public int IdCliente { get; private set; }
        public virtual Cliente Cliente { get; private set; }
        public int? IdRegra { get; private set; }
        public virtual Regra Regra { get; private set; }
        #endregion
    }
}
