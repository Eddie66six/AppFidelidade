using System;

namespace AppFidelidade.Dominio.Cliente.Entidade
{
    public class Compra
    {
        protected Compra()
        {

        }

        #region attr
        public int IdCompra { get; private set; }
        public decimal ValorCompra { get; private set; }
        public DateTime Data { get; private set; }
        public int IdFilial { get; private set; }
        public virtual Administracao.Entidade.Filial Filial { get; private set; }
        public int IdFuncionario { get; private set; }
        public virtual Funcionario.Entidade.Funcionario Funcionario { get; private set; }
        public int IdCliente { get; private set; }
        public virtual Cliente Cliente { get; private set; }
        public int? IdCarteira { get; private set; }
        public virtual Carteira Carteira { get; private set; }
        public int? IdRegra { get; private set; }
        public virtual Administracao.Entidade.Regra Regra { get; private set; }
        #endregion
    }
}
