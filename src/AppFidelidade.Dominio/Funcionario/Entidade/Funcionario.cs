using System.Collections.Generic;

namespace AppFidelidade.Dominio.Funcionario.Entidade
{
    public class Funcionario
    {
        protected Funcionario()
        {
            RegrasCadastradas = new List<Administracao.Entidade.Regra>();
            Filiais = new List<Administracao.Entidade.Filial>();
            Vendas = new List<Cliente.Entidade.Compra>();
        }

        #region attr
        public int IdFuncionario { get; private set; }
        public string Nome { get; private set; }
        public List<Administracao.Entidade.Regra> RegrasCadastradas { get; private set; }
        public List<Administracao.Entidade.Filial> Filiais { get; private set; }
        public List<Cliente.Entidade.Compra> Vendas { get; private set; }
        #endregion
    }
}
