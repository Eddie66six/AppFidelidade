using System;
using System.Collections.Generic;

namespace AppFidelidade.Dominio.Cliente.Entidade
{
    public class Carteira
    {
        protected Carteira()
        {
            Clientes = new List<Cliente>();
            Compras = new List<Compra>();
        }
        #region attr
        public int IdCarteira { get; private set; }
        public List<Cliente> Clientes { get; private set; }
        public List<Compra> Compras { get; private set; }
        #endregion
    }
}
