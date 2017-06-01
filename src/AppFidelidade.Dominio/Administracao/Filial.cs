using System.Collections.Generic;

namespace AppFidelidade.Dominio.Administracao
{
    public class Filial
    {
        protected Filial()
        {

        }
        #region attr
        public int IdFilial { get; set; }
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }
        public List<Funcionario.Funcionario> Funcionarios { get; set; }
        public List<Cliente.Cliente> Clientes { get; set; }
        public List<Regra> Regras { get; set; }
        public List<Cliente.Compra> Compras { get; set; }
        #endregion
    }
}
