using System;
using System.Collections.Generic;

namespace AppFidelidade.Dominio.Cliente.Entidade
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
