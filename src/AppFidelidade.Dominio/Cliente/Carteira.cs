using System.Collections.Generic;

namespace AppFidelidade.Dominio.Cliente
{
    public class Carteira
    {
        protected Carteira()
        {

        }
        #region attr
        public int IdCarteira { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Compra> Compras { get; set; }
        #endregion
    }
}
