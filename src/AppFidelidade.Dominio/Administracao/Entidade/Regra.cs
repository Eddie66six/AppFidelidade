using System.Collections.Generic;

namespace AppFidelidade.Dominio.Administracao.Entidade
{
    public class Regra
    {
        protected Regra()
        {
            Compras = new List<Cliente.Entidade.Compra>();
        }

        #region attr
        public int IdRegra { get; private set; }
        public Enum.ETipoDesconto TipoDesconto { get; private set; }
        public decimal ValorInicial { get; private set; }
        public decimal ValorFinal { get; private set; }
        public bool Inativo { get; private set; }
        public int IdFilial { get; private set; }
        public virtual Filial Filial { get; private set; }
        public int IdFuncionario { get; private set; }
        public virtual Funcionario.Entidade.Funcionario FuncionarioCadastro { get; private set; }
        public List<Cliente.Entidade.Compra> Compras { get; private set; }
        #endregion
    }
}
