using System.Collections.Generic;

namespace AppFidelidade.Dominio.Funcionario
{
    public class Funcionario
    {
        protected Funcionario()
        {
            RegrasCadastradas = new List<Administracao.Regra>();
        }

        #region attr
        public int IdFuncionario { get; set; }
        public List<Administracao.Regra> RegrasCadastradas { get; set; }
        public List<Administracao.Filial> Filiais { get; set; }
        public List<Cliente.Compra> Vendas { get; set; }
        #endregion
    }
}
