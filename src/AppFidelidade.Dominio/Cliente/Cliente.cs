using System.Collections.Generic;

namespace AppFidelidade.Dominio.Cliente
{
    public class Cliente
    {
        protected Cliente()
        {

        }

        #region attr
        public int IdCliente { get; set; }
        public int IdCarteira { get; set; }
        public virtual Carteira Carteira { get; set; }
        public List<Administracao.Filial> Filiais { get; set; }
        public List<Compra> Compras { get; set; }
        #endregion
    }
}
