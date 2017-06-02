using System.Collections.Generic;

namespace AppFidelidade.Dominio.Funcionario.Entidade
{
    public class Funcionario
    {
        protected Funcionario()
        {
            RegrasCadastradas = new List<Administracao.Entidade.Regra>();
        }

        #region attr
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public List<Administracao.Entidade.Regra> RegrasCadastradas { get; set; }
        public List<Administracao.Entidade.Filial> Filiais { get; set; }
        public List<Cliente.Entidade.Compra> Vendas { get; set; }
        #endregion
    }
}
