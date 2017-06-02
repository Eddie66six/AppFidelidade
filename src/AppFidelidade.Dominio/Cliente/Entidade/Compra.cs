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
        public Compra(decimal valorCompra,Filial filial,Funcionario.Entidade.Funcionario funcionario,Cliente cliente)
        {
            ValorCompra = valorCompra;
            Filial = filial;
            Funcionario = funcionario;
            Cliente = cliente;
            Data = DateTime.Now;

            _FinalizarCompra();
        }

        #region Metodos
        private void _FinalizarCompra()
        {
            Cliente.AdicionarCompra(this);
            Regra = Filial.ObterRegra(ValorCompra);
            if (!Cliente.Filiais.Any(p => p == Filial))
                Cliente.Filiais.Add(Filial);
        }
        #endregion
        #region attr
        public int IdCompra { get; private set; }
        public decimal ValorCompra { get; private set; }
        public DateTime Data { get; private set; }
        public int IdFilial { get; private set; }
        public virtual Filial Filial { get; private set; }
        public int IdFuncionario { get; private set; }
        public virtual Funcionario.Entidade.Funcionario Funcionario { get; private set; }
        public int IdCliente { get; private set; }
        public virtual Cliente Cliente { get; private set; }
        public int? IdCarteira { get; private set; }
        public virtual Carteira Carteira { get; private set; }
        public int? IdRegra { get; private set; }
        public virtual Regra Regra { get; private set; }
        #endregion
    }
}
