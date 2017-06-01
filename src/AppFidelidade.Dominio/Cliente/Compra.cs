namespace AppFidelidade.Dominio.Cliente
{
    public class Compra
    {
        protected Compra()
        {

        }

        #region attr
        public int IdCompra { get; set; }
        public int IdFilial { get; set; }
        public virtual Administracao.Filial Filial { get; set; }
        public int IdFuncionario { get; set; }
        public virtual Funcionario.Funcionario Funcionario { get; set; }
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int IdCarteira { get; set; }
        public virtual Carteira Carteira { get; set; }
        #endregion
    }
}
