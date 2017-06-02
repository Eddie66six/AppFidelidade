using System.Collections.Generic;

namespace AppFidelidade.Dominio.Administracao.Entidade
{
    public class Filial
    {
        protected Filial()
        {
            Funcionarios = new List<Funcionario.Entidade.Funcionario>();
            Clientes = new List<Cliente.Entidade.Cliente>();
            Regras = new List<Regra>();
            Compras = new List<Cliente.Entidade.Compra>();
        }
        #region attr
        public int IdFilial { get; private set; }
        public string Cnpj { get; private set; }
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public int IdEmpresa { get; private set; }
        public virtual Empresa Empresa { get; private set; }
        public List<Funcionario.Entidade.Funcionario> Funcionarios { get; private set; }
        public List<Cliente.Entidade.Cliente> Clientes { get; private set; }
        public List<Regra> Regras { get; private set; }
        public List<Cliente.Entidade.Compra> Compras { get; private set; }
        #endregion
    }
}
