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

        public Regra(string nome, Enum.ETipoDesconto tipoDesconto, decimal valorAcimaDe, decimal valorDaRegra, int idFilial, int idFuncionarioCadastro)
        {
            Compras = new List<Cliente.Entidade.Compra>();
            Nome = nome;
            TipoDesconto = tipoDesconto;
            ValorAcimaDe = valorAcimaDe;
            ValorDaRegra = valorDaRegra;
            IdFilial = idFilial;
            IdFuncionario = idFuncionarioCadastro;
        }

        #region Metodo
        public void AtivarDesativar()
        {
            Inativo = !Inativo;
        }
        #endregion

        #region attr
        public int IdRegra { get; private set; }
        public string Nome { get; set; }
        public Enum.ETipoDesconto TipoDesconto { get; private set; }
        public decimal ValorDaRegra { get;private set; }
        public decimal ValorAcimaDe { get; private set; }
        public bool Inativo { get; private set; }
        public int IdFilial { get; private set; }
        public virtual Filial Filial { get; private set; }
        public int IdFuncionario { get; private set; }
        public virtual Funcionario.Entidade.Funcionario FuncionarioCadastro { get; private set; }
        public List<Cliente.Entidade.Compra> Compras { get; private set; }
        #endregion
    }
}
