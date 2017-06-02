using System.Collections.Generic;

namespace AppFidelidade.Dominio.Cliente.Entidade
{
    public class Cliente
    {
        protected Cliente()
        {
            Filiais = new List<Administracao.Entidade.Filial>();
            Compras = new List<Compra>();
        }

        #region attr
        public int IdCliente { get; private set; }
        public string Nome { get; private set; }
        public int IdCarteira { get; private set; }
        public virtual Carteira Carteira { get; private set; }
        public List<Administracao.Entidade.Filial> Filiais { get; private set; }
        public List<Compra> Compras { get; private set; }
        #endregion
    }
}
