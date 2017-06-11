using System;
using System.Collections.Generic;

namespace AppFidelidade.Dominio.Administracao.Entidade
{
    public class Regra
    {
        protected Regra()
        {
            Compras = new List<Cliente.Entidade.Compra>();
        }

        public Regra(Enum.ETipoDesconto tipoDesconto, decimal valorInicial, decimal valorFinal,decimal valorDaRegra, Filial filial, Funcionario.Entidade.Funcionario funcionarioCadastro)
        {
            Compras = new List<Cliente.Entidade.Compra>();
            TipoDesconto = tipoDesconto;
            ValorInicial = valorInicial;
            ValorFinal = valorFinal;
            ValorDaRegra = valorDaRegra;
            Filial = filial;
            FuncionarioCadastro = funcionarioCadastro;
        }

        #region Metodo
        public void Excluir()
        {
            DataExclusao = DateTime.UtcNow;
        }
        #endregion

        #region attr
        public int IdRegra { get; private set; }
        public Enum.ETipoDesconto TipoDesconto { get; private set; }
        public decimal ValorDaRegra { get;private set; }
        public decimal ValorInicial { get; private set; }
        public decimal ValorFinal { get; private set; }
        public bool Inativo { get; private set; }
        public DateTime? DataExclusao { get;private set; }
        public int IdFilial { get; private set; }
        public virtual Filial Filial { get; private set; }
        public int IdFuncionario { get; private set; }
        public virtual Funcionario.Entidade.Funcionario FuncionarioCadastro { get; private set; }
        public List<Cliente.Entidade.Compra> Compras { get; private set; }
        #endregion
    }
}
