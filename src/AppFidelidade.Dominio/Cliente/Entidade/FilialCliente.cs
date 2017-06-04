using AppFidelidade.Dominio.Administracao.Entidade;
using System.Collections.Generic;

namespace AppFidelidade.Dominio.Cliente.Entidade
{
    public class FilialCliente
    {
        protected FilialCliente()
        {

        }

        public FilialCliente(Cliente cliente, Filial filial)
        {
            Cliente = cliente;
            Filial = filial;
        }

        #region Metodos
        public void InserirCredito(decimal valor)
        {
            ValorCreditoNaFilial += valor;
        }
        public void RemoverCredito(decimal valor)
        {
            ValorCreditoNaFilial -= valor;
        }
        #endregion
        #region attr
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int IdFilial { get; set; }
        public Filial Filial { get; set; }
        public decimal ValorCreditoNaFilial { get; set; }
        #endregion
    }
}
