using System.Collections.Generic;

namespace AppFidelidade.Dominio.Cliente.Entidade
{
    public class Cliente
    {
        protected Cliente()
        {

        }

        #region attr
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public int IdCarteira { get; set; }
        public virtual Carteira Carteira { get; set; }
        public List<Administracao.Entidade.Filial> Filiais { get; set; }
        public List<Compra> Compras { get; set; }
        #endregion
    }
}
