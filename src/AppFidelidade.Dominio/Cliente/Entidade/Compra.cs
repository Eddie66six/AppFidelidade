using System;

namespace AppFidelidade.Dominio.Cliente.Entidade
{
    public class Compra
    {
        protected Compra()
        {

        }

        #region attr
        public int IdCompra { get; set; }
        public decimal ValorCompra { get; set; }
        public DateTime Data { get; set; }
        public int IdFilial { get; set; }
        public virtual Administracao.Entidade.Filial Filial { get; set; }
        public int IdFuncionario { get; set; }
        public virtual Funcionario.Entidade.Funcionario Funcionario { get; set; }
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int? IdCarteira { get; set; }
        public virtual Carteira Carteira { get; set; }
        public int? IdRegra { get; set; }
        public virtual Administracao.Entidade.Regra Regra { get; set; }
        #endregion
    }
}
