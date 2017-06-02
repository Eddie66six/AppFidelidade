using System.Collections.Generic;

namespace AppFidelidade.Dominio.Administracao.Entidade
{
    public class Filial
    {
        protected Filial()
        {

        }
        #region attr
        public int IdFilial { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }
        public List<Funcionario.Entidade.Funcionario> Funcionarios { get; set; }
        public List<Cliente.Entidade.Cliente> Clientes { get; set; }
        public List<Regra> Regras { get; set; }
        public List<Cliente.Entidade.Compra> Compras { get; set; }
        #endregion
    }
}
