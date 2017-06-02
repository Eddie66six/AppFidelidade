using System.Collections.Generic;

namespace AppFidelidade.Dominio.Administracao.Entidade
{
    public class Regra
    {
        protected Regra()
        {

        }

        #region attr
        public int IdRegra { get; set; }
        public Enum.ETipoDesconto TipoDesconto { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal ValorFinal { get; set; }
        public bool Inativo { get; set; }
        public int IdFilial { get; set; }
        public virtual Filial Filial { get; set; }
        public int IdFuncionario { get; set; }
        public virtual Funcionario.Entidade.Funcionario FuncionarioCadastro { get; set; }
        public List<Cliente.Entidade.Compra> Compras { get; set; }
        #endregion
    }
}
